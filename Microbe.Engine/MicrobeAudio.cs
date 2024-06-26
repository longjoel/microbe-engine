﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
namespace Microbe.Engine
{
    public class SampleSegment
    {
        public string sn = "C4";       // sine note
        public double sv;       // sine volume
        public string tn = "C4";       // triangle note
        public double tv;       // triangle volume
        public string sqn = "C4";      // square wave note
        public double sqv;      // square wave volume
        public double nv;       // noise volume
    }

    public class Sample
    {
        public int IntervalMS { get; set; }
        public List<SampleSegment> SampleSegments { get; set; }

        public Sample()
        {
            SampleSegments = new List<SampleSegment>();
            IntervalMS = 100;
        }
    }
    public class MicrobeAudio : IMicrobeAudio
    {
        public Sample[] Samples { get; set; }

        private byte[][] _samplesCache;


        private Dictionary<string, double> _notes;
        private SoundPlayer _bgMusicPlayer;

        public List<string> Notes
        {
            get
            {

                return

                    _notes.Keys.ToList();
            }
        }



        public MicrobeAudio()
        {
            _notes = new Dictionary<string, double>();
            _samplesCache = new byte[256][];
            Samples = new Sample[256];
            for (int i = 0; i < 256; i++)
            {
                Samples[i] = new Sample();
                _samplesCache[i] = new byte[0];
            }
            var noteFrequency = Properties.Resources.note_frequency.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 0).ToList();
            for (int i = 1; i < noteFrequency.Count(); i++)
            {
                var row = noteFrequency[i];
                var parts = row.Split(',');
                _notes[parts[0].Trim()] = double.Parse(parts[1]);
            }
        }
        public void SetSampleRaw(int index, byte[] sampleData)
        {
            _samplesCache[index] = MakeWave(sampleData);
        }
        public void SetSample(int index, int intervalMS, SampleSegment[] musicSegments)
        {

            Samples[index].IntervalMS = intervalMS;
            Samples[index].SampleSegments = musicSegments.ToList();

            var sampleData = new List<byte>();

            for (int i = 0; i < musicSegments.Length; i++)
            {
                sampleData.AddRange(
                        MixSamples(
                            GenerateSineWave((int)_notes[musicSegments[i].sn], intervalMS, musicSegments[i].sv),
                            MixSamples(
                                GenerateSquareWave((int)_notes[musicSegments[i].sqn], intervalMS, musicSegments[i].sqv),
                                MixSamples(
                                    GenerateTriangleWave((int)_notes[musicSegments[i].tn], intervalMS, musicSegments[i].tv),
                                    GenerateWhiteNoise(intervalMS, musicSegments[i].nv)))));


            }

            var wav = MakeWave(sampleData.ToArray());

            _samplesCache[index] = wav;
        }

        public void PlayMusic(int sampleId)
        {
            if (_bgMusicPlayer != null)
            {
                _bgMusicPlayer.Stop();
                _bgMusicPlayer.Dispose();
            }
            using (var stream = new MemoryStream(_samplesCache[sampleId]))
            {
                _bgMusicPlayer = new SoundPlayer(stream);
                _bgMusicPlayer.PlayLooping();

            }
        }

        public void StopMusic()
        {
            if (_bgMusicPlayer != null)
            {
                _bgMusicPlayer.Stop();
                _bgMusicPlayer.Dispose();
            }
        }

        public void PlayEffect(int sampleId)
        {
            using (var stream = new MemoryStream(_samplesCache[sampleId]))
            {
                using (var player = new SoundPlayer(stream))
                {
                    player.Play();
                }
            }
        }

        static byte[] GenerateSineWave(int frequency, int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz

            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform

            int totalSamples = (sampleRate * durationMS) / 1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate; // Time in seconds
                double sineValue = Math.Sin(2.0 * Math.PI * frequency * t); // Sine wave value at time t
                waveData[i] = Convert.ToByte(((sineValue + 1) * 127.5) * volume * .75); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume
            }
            return waveData;
        }

        public static byte[] GenerateWhiteNoise(int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz


            int totalSamples = (sampleRate * durationMS) / 1000;
            byte[] waveData = new byte[totalSamples];

            Random rnd = new Random();

            for (int i = 0; i < totalSamples; i++)
            {
                double noiseValue = rnd.NextDouble() * 2.0 - 1.0; // Random value between -1 and 1
                waveData[i] = Convert.ToByte(((noiseValue + 1) * 127.5) * volume * .75); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume
            }

            return waveData;
        }

        static byte[] GenerateTriangleWave(int frequency, int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz

            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform
            double amplitude = -1; // Start at the minimum

            int totalSamples = (sampleRate * durationMS) / 1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                waveData[i] = Convert.ToByte(((amplitude + 1) * 127.5) * volume * .75); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume

                // Increase or decrease amplitude
                if (i % samplesPerWaveLength < samplesPerWaveLength / 2)
                {
                    amplitude += ampStep;
                }
                else
                {
                    amplitude -= ampStep;
                }
            }
            return waveData;
        }
        static byte[] GenerateSquareWave(int frequency, int durationMS, double volume)
        {
            int sampleRate = 48000; // 48 kHz


            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform
            double amplitude = -1; // Start at the minimum

            int totalSamples = (sampleRate * durationMS) / 1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                waveData[i] = Convert.ToByte((amplitude + 1) * 127.5 * volume * .75); // Convert amplitude range from [-1, 1] to [0, 255]

                // Flip amplitude at every half wavelength
                if (i % (samplesPerWaveLength / 2) == 0)
                {
                    amplitude = -amplitude;
                }
            }

            return waveData;
        }

        public static byte[] MixSamples(byte[] sample1, byte[] sample2)
        {
            int minLength = Math.Min(sample1.Length, sample2.Length);
            int maxLength = Math.Max(sample1.Length, sample2.Length);

            byte[] mixedSamples = new byte[maxLength];

            for (int i = 0; i < minLength; i += 2)
            {
                // Convert samples to 16-bit (from byte to short)
                short sample1Short = BitConverter.ToInt16(sample1, i);
                short sample2Short = BitConverter.ToInt16(sample2, i);

                // Mix samples
                short mixedSample = (short)((sample1Short + sample2Short) / 2);

                // Convert mixed sample back to 8-bit and store in output array
                byte[] mixedSampleBytes = BitConverter.GetBytes(mixedSample);

                mixedSamples[i] = mixedSampleBytes[0];
                mixedSamples[i + 1] = mixedSampleBytes[1];
            }

            // If one sample is longer than the other, append the remainder of the longer sample to the mix
            if (sample1.Length != sample2.Length)
            {
                byte[] longerSample = sample1.Length > sample2.Length ? sample1 : sample2;
                Array.Copy(longerSample, minLength, mixedSamples, minLength, maxLength - minLength);
            }

            return mixedSamples;
        }


        public static byte[] MakeWave(byte[] waveData)
        {

            int sampleRate = 48000; // 48 kHz
            int bitDepth = 8; // 8 bits
            int numChannels = 1; // Mono

            // Create a memory stream and a binary writer to write the WAV file
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            // Write the WAV file header
            writer.Write(new char[4] { 'R', 'I', 'F', 'F' });
            writer.Write(36 + waveData.Length);
            writer.Write(new char[4] { 'W', 'A', 'V', 'E' });
            writer.Write(new char[4] { 'f', 'm', 't', ' ' });
            writer.Write(16);
            writer.Write((short)1);
            writer.Write((short)numChannels);
            writer.Write(sampleRate);
            writer.Write(sampleRate * numChannels * bitDepth / 8);
            writer.Write((short)(numChannels * bitDepth / 8));
            writer.Write((short)bitDepth);

            // Write the data chunk header
            writer.Write(new char[4] { 'd', 'a', 't', 'a' });
            writer.Write(waveData.Length);

            // Write the wave data
            writer.Write(waveData);

            return stream.ToArray();

        }

        internal void Serialize(string fileName)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 256; i++)
            {
                sb.AppendLine($"[SAMPLE:{i}]");
                sb.AppendLine($"IntervalMS:{Samples[i].IntervalMS}");
                foreach (var s in Samples[i].SampleSegments)
                {
                    sb.AppendLine(string.Format("Segment:sn:{0},sv:{1},tn:{2},tv:{3},sqn:{4},sqv:{5},nv:{6}", s.sn, s.sv, s.tn, s.tv, s.sqn, s.sqv, s.nv));
                }

            }
            File.WriteAllText(fileName, sb.ToString());
        }

        public void Deserialize(string fileName)
        {
            if (File.Exists(fileName))
            {
                var content = File.ReadAllText(fileName);

                var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var sampleIndex = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("[SAMPLE:"))
                    {
                        sampleIndex = int.Parse(lines[i].Replace("[SAMPLE:", "").Replace("]", ""));
                        Samples[sampleIndex].SampleSegments.Clear();
                    }
                    if (lines[i].StartsWith("IntervalMS:"))
                    {
                        Samples[sampleIndex].IntervalMS = int.Parse(lines[i].Replace("IntervalMS:", ""));
                    }
                    else if (lines[i].StartsWith("Segment:"))
                    {
                        var parts = lines[i].Replace("Segment:", "").Split(',');
                        var s = new SampleSegment();
                        foreach (var p in parts)
                        {
                            var kv = p.Split(':');
                            switch (kv[0])
                            {
                                case "sn":
                                    s.sn = kv[1];
                                    break;
                                case "sv":
                                    s.sv = double.Parse(kv[1]);
                                    break;
                                case "tn":
                                    s.tn = kv[1];
                                    break;
                                case "tv":
                                    s.tv = double.Parse(kv[1]);
                                    break;
                                case "sqn":
                                    s.sqn = kv[1];
                                    break;
                                case "sqv":
                                    s.sqv = double.Parse(kv[1]);
                                    break;
                                case "nv":
                                    s.nv = double.Parse(kv[1]);
                                    break;
                            }
                        }
                        Samples[sampleIndex].SampleSegments.Add(s);
                    }
                }
            }
        }
    }
}

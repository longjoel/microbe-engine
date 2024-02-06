using Esprima.Ast;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Microbe.Engine
{
    public class MicrobeAudio
    {
        public static byte[] GenerateSineWave(int frequency, int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz
            int bitDepth = 8; // 8 bits
            int numChannels = 1; // Mono

            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform

            int totalSamples = (sampleRate * durationMS)/1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate; // Time in seconds
                double sineValue = Math.Sin(2.0 * Math.PI * frequency * t); // Sine wave value at time t
                waveData[i] = Convert.ToByte(((sineValue + 1) * 127.5) * volume); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume
            }

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

            // Return the memory stream containing the WAV file
            return stream.ToArray();
        }

        public static byte[] GenerateWhiteNoise(int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz
            int bitDepth = 8; // 8 bits
            int numChannels = 1; // Mono

            int totalSamples = (sampleRate * durationMS)/1000;
            byte[] waveData = new byte[totalSamples];

            Random rnd = new Random();

            for (int i = 0; i < totalSamples; i++)
            {
                double noiseValue = rnd.NextDouble() * 2.0 - 1.0; // Random value between -1 and 1
                waveData[i] = Convert.ToByte(((noiseValue + 1) * 127.5) * volume); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume
            }

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

            // Return the memory stream containing the WAV file
            return stream.ToArray();
        }

        public static byte[] GenerateTriangleWave(int frequency, int durationMS, double volume)
        {
            if (volume < 0.0 || volume > 1.0)
            {
                throw new ArgumentOutOfRangeException("volume", "Volume must be between 0.0 and 1.0");
            }

            int sampleRate = 48000; // 48 kHz
            int bitDepth = 8; // 8 bits
            int numChannels = 1; // Mono

            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform
            double amplitude = -1; // Start at the minimum

            int totalSamples = (sampleRate * durationMS)/1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                waveData[i] = Convert.ToByte(((amplitude + 1) * 127.5) * volume); // Convert amplitude range from [-1, 1] to [0, 255] and apply volume

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

            // Return the memory stream containing the WAV file
            return stream.ToArray();
        }
        public static byte[] GenerateSquareWave(int frequency, int durationMS, double volume)
        {
            int sampleRate = 48000; // 48 kHz
            int bitDepth = 8; // 8 bits
            int numChannels = 1; // Mono

            double samplesPerWaveLength = sampleRate / frequency;
            double ampStep = (2.0 / samplesPerWaveLength); // The "height" of the waveform
            double amplitude = -1; // Start at the minimum

            int totalSamples = (sampleRate * durationMS) / 1000;
            byte[] waveData = new byte[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                waveData[i] = Convert.ToByte((amplitude + 1) * 127.5 * volume); // Convert amplitude range from [-1, 1] to [0, 255]

                // Flip amplitude at every half wavelength
                if (i % (samplesPerWaveLength / 2) == 0)
                {
                    amplitude = -amplitude;
                }
            }

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

        public static void PlaySound(byte[] waveData)
        {
            using (var stream = new MemoryStream(waveData))
            {
                var player = new SoundPlayer(stream);
                player.PlaySync();
            }
        }
    }
}

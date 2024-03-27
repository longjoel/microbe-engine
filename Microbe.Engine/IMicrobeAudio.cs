using System.Collections.Generic;

namespace Microbe.Engine
{
    public interface IMicrobeAudio
    {
        List<string> Notes { get; }
        Sample[] Samples { get; set; }

        void Deserialize(string fileName);
        void PlayEffect(int sampleId);
        void PlayMusic(int sampleId);
        void SetSample(int index, int intervalMS, SampleSegment[] musicSegments);
        void SetSampleRaw(int index, byte[] sampleData);
        void StopMusic();
    }
}
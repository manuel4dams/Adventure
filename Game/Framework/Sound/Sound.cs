using System.IO;
using NAudio.Wave;

namespace Framework.Sound
{
    public class Sound
    {
        private readonly WaveFileReader audioFile;

        public Sound(Stream audioFileResource)
        {
            audioFile = new WaveFileReader(audioFileResource);
        }

        public void Play()
        {
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }
    }
}
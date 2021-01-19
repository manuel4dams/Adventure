using System.IO;
using NAudio.Wave;

namespace Framework.Sound
{
    public class Sound
    {
        private readonly WaveFileReader audioFile;
        private readonly bool loop;

        public Sound(Stream audioFileResource, bool loop = false)
        {
            audioFile = new WaveFileReader(audioFileResource);
            this.loop = loop;
        }

        // Volume of 0.0f is silence and 1.0f is the maximum value
        public void Play(float volume = 0.2f)
        {
            var outputDevice = new WaveOutEvent();
            if (loop)
            {
                var looped = new LoopStream(audioFile);
                outputDevice.Init(looped);
            }
            else
            {
                outputDevice.Init(audioFile);
            }

            outputDevice.Volume = volume;
            outputDevice.Play();
        }
    }
}
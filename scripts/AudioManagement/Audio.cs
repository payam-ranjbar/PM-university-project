using UnityEngine;

namespace AudioManagement
{
    public class Audio
    {
        [SerializeField] public string name;
        [SerializeField] private AudioClip clip;
        [SerializeField] [Range(0f, 1f)] private float volume = 1f;
        [SerializeField] [Range(-3f, 3f)] private float pitch = 1f;

        private AudioSource _source;

        public Audio(string name, AudioClip clip, float volume, float pitch)
        {
            this.name = name;
            this.clip = clip;
            this.volume = volume;
            this.pitch = pitch;
        }

        public void Play(AudioSource source)
        {
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        
        
    }
}
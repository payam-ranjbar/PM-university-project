using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AudioManagement
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour, IAudioPlayer
    {
        public List<Audio> soundEffects;
        
        public List<Audio> SoundEffects => soundEffects;

        private AudioSource _source;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }
        
        public void PlayByName(string name)
        {
            var audio = Array.Find(SoundEffects.ToArray(), sound => sound.name == name);
            if (audio != null)
            {
                audio.Play(_source);
            }
            else
            {
                throw new Exception("Audio Clip Not Found");
            }
            
        }
}
}
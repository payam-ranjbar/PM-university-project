using System.Collections.Generic;
using UnityEngine;

namespace AudioManagement
{
    
    public interface IAudioPlayer
    {
        List<Audio> SoundEffects { get;}
    }
}
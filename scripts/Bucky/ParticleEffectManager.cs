using System;

using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{

    public PEffect[] Effects;

     void Start()
    {
        
    }

    public void Play(string n ,float direction = 0)
    {
        var effect = Array.Find(Effects, Effects => Effects.name == n);
        effect.play(direction);
    }
}

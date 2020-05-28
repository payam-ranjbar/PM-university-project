using System;
using UnityEngine;

public class SoundEffectsManger : MonoBehaviour
{
    public SoundEffect[] Effcets;

    public void play(string n)
    {
        var effect = Array.Find(Effcets, Effects => Effects.name == n);
        effect.play();

    }
}

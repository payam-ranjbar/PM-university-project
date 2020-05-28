
using UnityEngine;
using Random = System.Random;

public class PlayerSoundEffects : MonoBehaviour
{
    public AudioClip [] footStepEffects;

    public AudioClip GroundHitEffect;
    public AudioClip JumpEffect;
    public AudioClip DashEffect;
    public AudioClip WeaponSwitchEffect;
    
    private AudioSource footStepsAudioSource;
    private AudioSource groundHitAudioSource;

    private void Start()
    {
        footStepsAudioSource = addAudioSource();
        footStepsAudioSource.pitch = 0.77f;
        groundHitAudioSource = addAudioSource();
    }

    private AudioSource addAudioSource()
    {
        return gameObject.AddComponent<AudioSource>();
    }

    private void play(AudioClip clip, AudioSource audioSource)
    {

        audioSource.clip = clip;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }        
    }
    
    public void playFootStepEffects()
    {
        Random rand = new Random();
        var RandomEffect = footStepEffects[rand.Next(footStepEffects.Length)];
        
        play(RandomEffect, footStepsAudioSource);
    }

    public void playGroundHitEffect()
    {
        play(GroundHitEffect, groundHitAudioSource);
    }      
    public void playDashEffect()
    {
        play(DashEffect, groundHitAudioSource);
    }    
    public void playJumpEffect()
    {
        play(JumpEffect, groundHitAudioSource);
    }
    

    
}

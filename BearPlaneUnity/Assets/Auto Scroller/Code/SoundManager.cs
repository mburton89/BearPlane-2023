using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float minRandomPitch;
    [SerializeField] float maxRandomPitch;

    [SerializeField] List<AudioSource> explosionSounds;
    int explosionSoundIndex;

    [SerializeField] List<AudioSource> gutsSounds;
    int gutsSoundIndex;

    [SerializeField] List<AudioSource> bearSounds;
    int bearSoundIndex;

    [SerializeField] List<AudioSource> shoutSounds;
    int shoutSoundIndex;

    [SerializeField] List<AudioSource> parachuteSounds;
    int parachuteSoundIndex;

    [SerializeField] List<AudioSource> ejectSounds;
    int ejectSoundIndex;

    public enum SoundEffect
    {
        Explosion,
        Guts,
        Bear,
        Shout,
        Parachute,
        Eject
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        AudioSource audioSourceToPlay;
        float randPitch = Random.Range(minRandomPitch, maxRandomPitch);

        if (soundEffect == SoundEffect.Explosion)
        {
            audioSourceToPlay = explosionSounds[explosionSoundIndex];
            if (explosionSoundIndex < explosionSounds.Count - 1)
            {
                explosionSoundIndex++;
            }
            else
            {
                explosionSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.Guts)
        {
            audioSourceToPlay = gutsSounds[gutsSoundIndex];
            if (gutsSoundIndex < gutsSounds.Count - 1)
            {
                gutsSoundIndex++;
            }
            else
            {
                gutsSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.Bear)
        {
            audioSourceToPlay = bearSounds[bearSoundIndex];
            if (bearSoundIndex < bearSounds.Count - 1)
            {
                bearSoundIndex++;
            }
            else
            {
                bearSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.Shout)
        {
            audioSourceToPlay = shoutSounds[shoutSoundIndex];
            if (shoutSoundIndex < shoutSounds.Count - 1)
            {
                shoutSoundIndex++;
            }
            else
            {
                shoutSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.Parachute)
        {
            audioSourceToPlay = parachuteSounds[parachuteSoundIndex];
            if (parachuteSoundIndex < parachuteSounds.Count - 1)
            {
                parachuteSoundIndex++;
            }
            else
            {
                parachuteSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.Eject)
        {
            audioSourceToPlay = ejectSounds[ejectSoundIndex];
            if (ejectSoundIndex < ejectSounds.Count - 1)
            {
                ejectSoundIndex++;
            }
            else
            {
                ejectSoundIndex = 0;
            }
        }

        else
        {
            audioSourceToPlay = null;
            Debug.LogError("Audio Source Not Assigned");
        }

        audioSourceToPlay.pitch = randPitch;
        audioSourceToPlay.Play();
    }
}

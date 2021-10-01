using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClips, AudioClip> audioClips = new Dictionary<AudioClips, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        initialized = true;
        audioClips.Add(AudioClips.Shoot, Resources.Load<AudioClip>("shoot"));
        audioClips.Add(AudioClips.BreakBlock, Resources.Load<AudioClip>("blockBroken"));
        audioClips.Add(AudioClips.Toasted, Resources.Load<AudioClip>("toasted"));
        audioClips.Add(AudioClips.Doused, Resources.Load<AudioClip>("doused"));
        audioClips.Add(AudioClips.Cleared, Resources.Load<AudioClip>("puzzleCleared"));
        audioClips.Add(AudioClips.Failed, Resources.Load<AudioClip>("puzzleFailed"));
        audioClips.Add(AudioClips.BlockSelect, Resources.Load<AudioClip>("blockSelect"));
        audioClips.Add(AudioClips.LevelSelect, Resources.Load<AudioClip>("levelSelect"));
        audioClips.Add(AudioClips.LevelLocked, Resources.Load<AudioClip>("levelLocked"));
        audioClips.Add(AudioClips.StandardJump, Resources.Load<AudioClip>("standardJump"));
        audioClips.Add(AudioClips.MelancholicJump, Resources.Load<AudioClip>("melancholicJump"));
        audioClips.Add(AudioClips.StandardDeath, Resources.Load<AudioClip>("standardDeath"));
        audioClips.Add(AudioClips.LevelCompleted, Resources.Load<AudioClip>("levelCompleted"));
        audioClips.Add(AudioClips.EscapeRope, Resources.Load<AudioClip>("escapeRope"));
        audioClips.Add(AudioClips.GamePaused, Resources.Load<AudioClip>("gamePaused"));
        audioClips.Add(AudioClips.OutOfBounds, Resources.Load<AudioClip>("outOfBounds"));
        EventManager.AddBrokenBlockListener(PlayAudioClip);
        EventManager.AddBlockSelectedListener(PlayAudioClip);
        EventManager.AddLevelSelectListener(PlayAudioClip);
        EventManager.AddPlayerSFXListener(PlayAudioClip);
        EventManager.AddLevelClearedListener(PlayAudioClip);
        EventManager.AddGeneralSFXListener(PlayAudioClip);
    }

    static void PlayAudioClip(AudioClips audioClip)
    {
        audioSource.PlayOneShot(audioClips[audioClip]);
    }
}

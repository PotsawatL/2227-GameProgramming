using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips hitAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips collectedAudioClips;
    [SerializeField] private SoAudioClips respawnedAudioClips;
    [SerializeField] private SoAudioClips sprungAudioClips;
    [SerializeField] private SoAudioClips winAudioClips;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip());
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip());
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitAudioClips.GetAudioClip());
    }

    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip());
    }

    public void PlayCollectedSound()
    {
        audioSource.PlayOneShot(collectedAudioClips.GetAudioClip());
    }

    public void PlayRespawnedSound()
    {
        audioSource.PlayOneShot(respawnedAudioClips.GetAudioClip());
    }

    public void PlaySprungSound()
    {
        audioSource.PlayOneShot(sprungAudioClips.GetAudioClip());
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winAudioClips.GetAudioClip());
    }
}

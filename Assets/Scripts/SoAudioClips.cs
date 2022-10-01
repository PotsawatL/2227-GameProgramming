using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create AudioClips", fileName = "New AudioClips")]
public class SoAudioClips : ScriptableObject
{
    [SerializeField] private AudioClip[] audioClips;

    public AudioClip GetAudioClip()
    {
        int totalAutioClip = audioClips.Length;
        int index;
        switch (totalAutioClip)
        {
            case 1:
                index = 0;
                break;
            default:
                index = Random.Range(0, totalAutioClip);
                break;
        }

        return audioClips[index];


    }
}
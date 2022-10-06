using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    [SerializeField] private AudioController playerAudioController;
    // Start is called before the first frame update

    public void WalkSound()
    {
        playerAudioController.PlayWalkSound();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void setAnimetorParameter(Vector2 playerVelocity, bool groundState)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(playerVelocity.x));
        animator.SetBool("IsGrounded", groundState);
        
    }
}
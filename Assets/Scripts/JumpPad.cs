using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private BoxCollider2D jumpPadColldier;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            animator.SetTrigger("Bounce");
            player.rb.AddForce(jumpPadForce * transform.up, ForceMode2D.Impulse);
        }

    }
}

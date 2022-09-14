using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CollectibleType playerColor;
    [SerializeField] private float moveInput = 0;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float Speed = 5;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Collectible collectible))
        {
            CollectibleType playerColor = collectible.color;

            switch (playerColor)
            {
                case CollectibleType.Red:
                    spriteRenderer.color = Color.red;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case CollectibleType.Blue:
                    spriteRenderer.color = Color.blue;
                    break;
            }
            Destroy(collectible.gameObject);
        }
    }

}
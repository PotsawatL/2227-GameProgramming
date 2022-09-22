using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerAnimatorController animatorController;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private CollectibleType playerColor;

    [Header("Player Values")]
    [SerializeField] private float Speed = 3f;
    [SerializeField] private float jumpForce = 10f;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("Grounded Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.01f;
    
    private float _moveInput;
    private bool _isGrounded;

    private Collider2D _playerCollider;
    private GameManager _gameManager;

    private void Start()
    {
        FindGameManager();
        _playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        //CheckGround();
        SetAnimatorParameters();
    }

    private void FindGameManager()
    {
        if (_gameManager != null) return;

        _gameManager = FindObjectOfType<GameManager>();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * Speed, rb.velocity.y);
        if (CheckGround())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); 
        rb.AddForce(force * transform.up, ForceMode2D.Impulse);
    }

    /*private void TryJumping()
    {
        if (!_isGrounded) return;
        Jump(jumpForce);
    }*/

    private void FlipPlayerSprite()
    {
        if (_moveInput < 0)
        {
            player.localScale = new Vector3(-1, 1, 1);
        }
        else if (_moveInput > 0)
        {
            player.localScale = Vector3.one;
        }
    }

    private bool CheckGround()
    {
        var playerBounds = _playerCollider.bounds;

        var raycastHit2D = Physics2D.BoxCast(playerBounds.center, playerBounds.size, 0f, Vector2.down, groundCheckDistance, groundLayers);

        return _isGrounded = raycastHit2D.collider != null;
    }

    private void SetAnimatorParameters()
    {
        animatorController.setAnimetorParameter(rb.velocity, _isGrounded);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        FlipPlayerSprite();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && coyoteTimeCounter > 0)
        {
            rb.AddForce((jumpForce * transform.up), ForceMode2D.Impulse);
            coyoteTimeCounter = 0;
        }
        //TryJumping();
    }

    IEnumerator Respawn (Collider2D collision, int time)
    {
        yield return new WaitForSeconds(time);

        collision.gameObject.SetActive(true);
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

            Debug.Log(collectible);

            collision.gameObject.SetActive(false);
            StartCoroutine(Respawn(collision, 4));
            
            //Destroy(collectible.gameObject);
        }

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            Debug.Log("Die");
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        FindGameManager();
        _gameManager.ProcessPlayerDeath();
    }

}
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private SpriteRenderer spritePlayer;
    [SerializeField] private ParticleSystem deathEffect;

    private Collider2D _playerCollider;
    [SerializeField]private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }

    public void Bounce(float jumpPadForce, float jumpTimeSleep)
    {
        playerController.Jump(jumpPadForce, jumpTimeSleep);
    }

    public void MuteFallImpactSounds()
    {
        audioController.MuteAudioSource();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Collectibles collectible))
        {
            var collectibleType = collectible.GetCollectibleInfoOnContact();

            switch (collectibleType)
            {
                case CollectibleType.DoubleJump:
                    playerController.EnableDoubleJump();
                    break;
                case CollectibleType.RefillHealth:
                case CollectibleType.RefillEnergy:
                case CollectibleType.RefillDash:
                default:
                    break;
            }
            
            Debug.Log(collectibleType);
        }

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            deathEffect.Play();
            Destroy(spritePlayer);
            playerController.TakeDamage();
            //StartCoroutine(Break());
        }

        /*IEnumerator Break()
        {
        
            yield return new WaitForSeconds(particleDeathEffect.main.startLifetime.constantMax);
            Destroy(gameObject);
        }*/

        #region Unused

        /*if (!col.TryGetComponent(out Collectibles collectible)) return;  
        // This is an inverted if. If the above condition is not met, return void (stop this function).
        
        var collectibleType = collectible.GetCollectibleInfoOnContact();

        switch (collectibleType)
            {
                case CollectibleType.Red:
                    spriteRenderer.color = redColor;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = greenColor;
                    break;
                case CollectibleType.Blue:
                    spriteRenderer.color = blueColor;
                    break;
            }*/

        #endregion
    }
}

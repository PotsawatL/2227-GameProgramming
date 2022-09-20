using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private SoCollectible soCollectible;
    public CollectibleType color;
    public PowerUp powerUp;

    private void Start()
    {
        powerUp = soCollectible.GetPowerUp();

        Debug.Log(soCollectible.GetCollectible());
        if (TryGetComponent(out RandomCollectible randomCollectible))
        {
            color = randomCollectible.color;
        }
    }
    CollectibleType getColor()
    {
        return this.color;
    }

    void setColor(CollectibleType color)
    {
        this.color = color;
    }

}
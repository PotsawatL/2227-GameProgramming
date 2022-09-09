using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType color;

    private void Start()
    {
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
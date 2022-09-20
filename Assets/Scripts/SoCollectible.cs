using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Collectible", menuName = "Collectibles")]

public class SoCollectible : ScriptableObject
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private PowerUp powerUp;
    [SerializeField] private string collectibleitem;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool isRespawnable;

    public string GetCollectible()
    {
        return collectibleitem;
    }

    public PowerUp GetPowerUp()
    {
        return powerUp;
    }
}

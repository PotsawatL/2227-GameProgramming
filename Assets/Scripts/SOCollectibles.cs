using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles", fileName = "New Collectible")]
public class SOCollectibles : ScriptableObject
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;

    public Sprite GetSprite() => sprite;
    public CollectibleType GetCollectibleType() => collectibleType;
    public Sprite GetOutlineSprite() => outlineSprite;
    public bool GetRespawnable() => respawnable;
}

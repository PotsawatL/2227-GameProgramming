using UnityEngine;

public class HideSpriteRendererOnStart : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

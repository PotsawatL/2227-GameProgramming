using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        FindGameManager();
    }

    private void FindGameManager()
    {
        if (_gameManager != null) return;
        
        _gameManager = FindObjectOfType<GameManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;


        FindGameManager();
        _gameManager.TriggerNextScene();
    }
}

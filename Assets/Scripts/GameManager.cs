using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private AudioController playerAudioController;
    [SerializeField] private LivesDisplay LivesDisplay = null;
    [SerializeField] private int lives = 3;
    // Simple singleton script. This is the easiest way to create and understand a singleton script.

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {

            Destroy(gameObject);
        }
        else
        {
            LivesDisplay.UpdateLives(lives);
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public void ProcessPlayerDeath()
    {
        SceneManager.LoadScene(GetCurrentBuildIndex());
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        //playerAudioController.PlayWinSound();
        LoadScene(nextSceneIndex);
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        DOTween.KillAll();
    }

    public void LoadMainMenu()
    {
        LoadScene(0);
        Destroy(gameObject);
    }

    public void DamagePlayer()
    {

        lives -= 1;

        if (lives == 0)
        {
            BGSound.Instance.gameObject.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(0);
            Destroy(gameObject);
            DOTween.KillAll();
        }
        else
        {
            ProcessPlayerDeath();
        }
        UpdateLives();
    }

    private void UpdateLives()
    {
        LivesDisplay.UpdateLives(lives);
    }

}

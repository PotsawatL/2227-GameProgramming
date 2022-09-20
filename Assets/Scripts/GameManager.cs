using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        var numGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        RestartScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }

    public void TriggerNextScene()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        var nextScenceBuildIndex = GetCurrentSceneIndex() + 1;
        if (nextScenceBuildIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextScenceBuildIndex = 0;
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextScenceBuildIndex);
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}

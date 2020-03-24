using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float delay = 1f;
    public GameObject levelClearUI;

    public void LevelClear()
    {
        levelClearUI.SetActive(true);
    }

    public void EndGame()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Invoke("Restart", delay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

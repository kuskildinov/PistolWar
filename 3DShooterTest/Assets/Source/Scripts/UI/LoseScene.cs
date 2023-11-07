using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{
    private const int MenuSceneIndex = 0;
    private const int GameSceneIndex = 1;
    public void RestartGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(MenuSceneIndex);
    }
}

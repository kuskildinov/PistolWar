using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const int GameSceneIndex = 1;
    public void StartGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }
}

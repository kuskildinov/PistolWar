using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private SceneRoot _sceneRoot;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private CharacterGun _characterGun;

    private IInput _input;

    private void Update()
    {
        if(_input.PauseButton())
        {
            OpenPausePanel();
        }
    }

    private void OpenPausePanel()
    {
        _PausePanel.SetActive(true);
        _sceneRoot.ActivateCursor();
        _characterGun._canShoot = false;
        Time.timeScale = 0;
    }

    public void ClosePausePanel()
    {
        _PausePanel.SetActive(false);
        _sceneRoot.DeactivateCursor();
        Time.timeScale = 1;
        _characterGun._canShoot = true ;
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Initialize(IInput input)
    {
        _input = input;
    }
}

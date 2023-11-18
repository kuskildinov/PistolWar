using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private SceneRoot _sceneRoot;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private CharacterMovment _characterMovment;
    [SerializeField] private CharacterRotation _characterRotation;
    [SerializeField] private CharacterGun _characterGun;

    private bool _isGamePaused;
    private IInput _input;

    private void Update()
    {
        if(_input.PauseButton())
        {
            if (_isGamePaused == false)
                OpenPausePanel();
            else
                ClosePausePanel();
        }
    }


    private void OpenPausePanel()
    {
        _characterMovment.DeactivateCharacterMovment();
        _characterRotation.DeactivateCharacterRotation();
        _characterGun._canShoot = false;
        _isGamePaused = true;

        _pausePanel.SetActive(true);
        _sceneRoot.ActivateCursor();
        
        Time.timeScale = 0;
    }

    private void ClosePausePanel()
    {
        _characterMovment.ActivateCharacterMovment();
        _characterRotation.ActivateCharacterRotation();
        _characterGun._canShoot = true;
        _isGamePaused = false;

        _pausePanel.SetActive(false);
        _sceneRoot.DeactivateCursor();
        
        Time.timeScale = 1;
       
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true) ;
    }

    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
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

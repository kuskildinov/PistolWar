using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoot : CompositeRoot
{
    [SerializeField] private bool _isCursorVisible; 
    public override void Compose()
    { 
        if(_isCursorVisible)
        {
            ActivateCursor();
        }
        else
        {
            DeactivateCursor();
        }
    }

    public void ActivateCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void DeactivateCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadCScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

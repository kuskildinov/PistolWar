using UnityEngine;
using Cinemachine;

public class CameraRoot : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCam;
    [SerializeField] private CinemachineVirtualCamera _pistolCam;
    private IInput _input;
    
    public void Initialize(IInput input)
    {
        _playerCam.gameObject.SetActive(true);
        _pistolCam.gameObject.SetActive(false);
        _input = input;        
    }

    private void Update()
    {        
        if (_input.TakeAim())
        {
            _pistolCam.gameObject.SetActive(true);
        }
        else _pistolCam.gameObject.SetActive(false);
    }
}

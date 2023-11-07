using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private CharacterMovment _characterMovment;
    [SerializeField] private CharacterRotation _characterRotation;
    [SerializeField] private CharacterGun _characterGun;
    [SerializeField] private CharacterAnimations _characterAnimations;
    [SerializeField] private CharacterAmmo _characterAmmo;
    [SerializeField] private CameraRoot _cameraRoot;
    [SerializeField] private GameSceneUI _gameSceneUI;
    private IInput _input;

    public override void Compose()
    {
        _input = new DesktopInput();
        _characterAnimations.Initialize(_input);
        _characterRotation.Initialize(_input);
        _characterMovment.Initialize(_input);
        _characterGun.Initialize(_input);
        _characterAmmo.Initialize(_input);
        _cameraRoot.Initialize(_input);
        _gameSceneUI.Initialize(_input);
    }
}

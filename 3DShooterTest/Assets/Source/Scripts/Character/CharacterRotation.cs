using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _sensitivity = 2f;
    [SerializeField] private Vector2 _verticalRange = new Vector2(-30f,25f);
    [SerializeField] private Transform _head;
    [SerializeField] private Rigidbody _rigidbody;

    private IInput _input;
    private float _horizontalRotation;
    private float _verticalRotation;
    private float _currentHorizontalRotation;

    
    private void LateUpdate()
    {
        ReadInput(_input);

        _rigidbody.rotation = Quaternion.Euler(0, _horizontalRotation * _sensitivity, 0);        
        _currentHorizontalRotation = Mathf.Clamp( _currentHorizontalRotation + _verticalRotation * _sensitivity, _verticalRange.x, _verticalRange.y) ;

        _head.localEulerAngles = new Vector3(_currentHorizontalRotation, 0f, 0f);
        _verticalRotation = 0;
    }
    
    private void ReadInput(IInput input)
    {
        _horizontalRotation += input.MouseHorizontalMove();
        _verticalRotation -= input.MouseVerticalMove();       
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private IInput _input;

    private void Update()
    {
        if(_input.Shoot())
        {
            _animator.SetTrigger("Shoot");
        }
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }
}

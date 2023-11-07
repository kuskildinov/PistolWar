using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{
    private const int GameLoseSceneIndex = 2;

    [SerializeField] private Slider _slider;
    [SerializeField] private SceneRoot _sceneRoot;

    private Health _heath;

    public void Initialize(Health health)
    {
        _heath = health;
        _heath.ValueChanged += OnValueChanged;
        _heath.Die += Dead;
        OnValueChanged();
    }    

    private void OnValueChanged()
    {
        SetHealthSlider();
    }

    private void SetHealthSlider()
    {
        _slider.value = _heath.CurrentHealth / _heath.MaxHealth;
    }

    private void Dead()
    {
        _heath.Die -= Dead;
        _heath.ValueChanged -= OnValueChanged;
        _sceneRoot.LoadCScene(GameLoseSceneIndex);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterAmmo : MonoBehaviour
{
    [SerializeField, Min(0)] private int _gunCapacity;
    [SerializeField] private CharacterGun _gun;
    [SerializeField] private TMP_Text _bulletsAmountText;

    private int _currentBulletAmount;
    private IInput _input;
    public void Initialize(IInput input)
    {
        _input = input;
        Activate();
        _gun.PlayerShoot += Shoot;
        _gun.GunReload += Reload;
        
    }

    private void Update()
    {
        if(IsAmmoEmpty())
        {
            _gun._canShoot = false;           
        }
        _bulletsAmountText.text = _currentBulletAmount.ToString();
    }
    private void Shoot()
    {
        _currentBulletAmount--;
    }

    private void Reload()
    {
        while(_currentBulletAmount < _gunCapacity)
        {
            _currentBulletAmount++;
        }
        _gun._canShoot = true;
    }

    private bool IsAmmoEmpty()
    {
        if (_currentBulletAmount <= 0)
            return true;
        return false;
    }

    private void Activate()
    {
        _currentBulletAmount = _gunCapacity;
    }
}

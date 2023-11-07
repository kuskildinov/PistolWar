using System;
using UnityEngine;
public class CharacterGun : Gun
{
    private IInput _input;

    public bool _canShoot = true;
    public event Action PlayerShoot;
    public event Action GunReload;

    protected override void Update()
    {        
        if (_input.Shoot() && _canShoot)
        {
            PlayerShoot?.Invoke();
            base.Update();
        }
        if(_input.GunReload())
        {
            GunReload?.Invoke();
        }
    }
    
    public void Initialize(IInput input)
    {
        _input = input;
    }
}

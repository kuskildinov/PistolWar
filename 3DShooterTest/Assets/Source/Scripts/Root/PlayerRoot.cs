using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : CompositeRoot
{
    [SerializeField] private Character _character;
    [SerializeField] private CharacterHUD _characterHUD;
    public override void Compose()
    {
        _character.Initialize();
        _characterHUD.Initialize(_character.Health);
    }
}

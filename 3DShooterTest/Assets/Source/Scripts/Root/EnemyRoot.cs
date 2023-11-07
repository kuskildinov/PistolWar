using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoot : CompositeRoot
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Character _character;
    public override void Compose()
    {
        _enemySpawner.Initialize(_character);
    }
}

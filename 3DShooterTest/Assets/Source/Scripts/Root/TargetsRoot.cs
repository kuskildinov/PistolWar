using UnityEngine;

public class TargetsRoot : CompositeRoot
{
    [SerializeField] private TargetSpawner _targetSpawner;
    public override void Compose()
    {
        _targetSpawner.Initialize();
    }
}

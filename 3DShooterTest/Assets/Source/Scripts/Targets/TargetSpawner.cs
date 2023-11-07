using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnCount = 2;
    [SerializeField] private Target[] _targets;

    public void Initialize()
    {
        DeactivateAllTarget();
        ActicivateRandomTarget();        
    }

    public void ActicivateRandomTarget()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Target newTarget = _targets[Random.Range(0, _targets.Length - 1)];
            newTarget.gameObject.SetActive(true);
            newTarget._canMatched = true;
        }        
    }

    private void DeactivateAllTarget()
    {
        foreach (Target target in _targets)
        {
            target.gameObject.SetActive(false);
            target._canMatched = false;
        }
    }
}

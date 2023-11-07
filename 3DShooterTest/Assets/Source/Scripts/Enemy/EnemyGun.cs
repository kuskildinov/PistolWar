using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{
    [SerializeField] private float _visionDistance;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _head;

    protected override void Update()
    {
        if (CanSeePlayer() && _enemy._isAlive)
        {
                _enemy._currentState = EnemyState.SHOOT;
                base.Update();
        }
        else _enemy._currentState = EnemyState.WALK;        
    }

    public bool CanSeePlayer()
    {        
        Ray ray = new Ray(_head.position, _head.forward * _visionDistance);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, _visionDistance))
        {
            if(hit.transform.gameObject.TryGetComponent<Character>(out Character character))
                return true;            
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_head.position, _head.forward * _visionDistance);
    }
}

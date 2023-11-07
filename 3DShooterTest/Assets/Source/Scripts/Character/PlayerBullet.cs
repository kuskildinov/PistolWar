using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{   
    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out IDamageble enemy))
        {
            enemy.TakeDamage(base._damage);
        }
        base.OnCollisionEnter(collision);
    }
}

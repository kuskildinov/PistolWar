using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageble player))
        {
            player.TakeDamage(base._damage);            
        }
        base.OnCollisionEnter(collision);
    }
}

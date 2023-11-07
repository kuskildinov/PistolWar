using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITargetable
{
    [SerializeField] private float _maxHealth;
    public Vector3 Position => transform.position;
    public Health Health { get; private set; }

    public void Initialize()
    {
        Health = new Health(_maxHealth);
    }
    public void TakeDamage(float damage)
    {
        Health.Decrease(damage);
    }

    public void TakeHP()
    {
        Health.Increase();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            TakeHP();
            firstAidKit.Deactivate();
        }
    }
}

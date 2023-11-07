using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _time;
    [SerializeField] private TrailRenderer _trail;

    protected float _damage;

    public void Init(Vector3 velocity, float damage)
    {
        _damage = damage;
        _trail.Clear();
        _rigidbody.velocity = velocity;
        StartCoroutine(DeleyDestroy());
    }

    private IEnumerator DeleyDestroy()
    {
        yield return new WaitForSecondsRealtime(_time);
        Deactivate();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

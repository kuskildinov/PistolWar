using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDeley;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private AudioSource _audioSource;
    
    private float _lastShootTime;    
    private Pool<Bullet> _pool;

    private void Start()
    {
        _pool = new Pool<Bullet>(_bulletTemplate, _bulletContainer, 20);
    }

    protected virtual void Update()
    {        
       Shoot();
    }
    private void Shoot()
    {
        if (Time.time - _lastShootTime < _shootDeley)
            return;
        _lastShootTime = Time.time;

        Bullet bullet = _pool.GetFreeElement();
        bullet.transform.position = _bulletPoint.position;
        bullet.Activate();
        Vector3 velocity = _bulletPoint.forward * _bulletSpeed;
        bullet.Init(velocity, _damage);
        _audioSource.Play();
    }
}

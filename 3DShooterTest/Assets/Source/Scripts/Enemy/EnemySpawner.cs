
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 10f;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _spawnCount;
    [SerializeField] private Transform _container;  
    
    private Character _character;
    private Coroutine _coroutine;
    private Pool<Enemy> _pool;
   
    public void Initialize(Character character)
    {
        _character = character;
        _pool = new Pool<Enemy>(_enemy, _container, _spawnCount);
        StartSpawn();
    }
    
    private void StartSpawn()
    {        
        _coroutine = StartCoroutine(Spawning());        
    }

    private IEnumerator Spawning()
    {
        for (int i = 0; i < _spawnCount - 1; i++)
        {
            yield return new WaitForSeconds(_spawnInterval);
            Enemy enemy = _pool.GetFreeElement();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
            enemy.Initialize(_character);
        }                      
    }

}

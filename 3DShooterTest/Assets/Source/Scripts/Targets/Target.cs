using System;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour, IDamageble
{
    private const int _destroyDeley = 1;

    [SerializeField] private GameObject _mesh;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TargetSpawner _spawner;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ScoreRoot _scoreRoot;
    [SerializeField] private TotalScore _totalScore;
    [SerializeField] private int _scoreForMatch;

    public event Action OnScoreIncrease;

    public bool _canMatched = true;
   
    public void TakeDamage(float damage)
    { 
        if(_canMatched)
        {
            _particle.gameObject.SetActive(true);
            _mesh.SetActive(false);

            _audioSource.PlayOneShot(_audioSource.clip);
            _totalScore.ScoreChanged(_scoreForMatch);
            StartCoroutine(DestroyDeley());

            OnScoreIncrease?.Invoke();           
            _canMatched = false;
        }
        
    }

    private IEnumerator DestroyDeley()
    {
        yield return new WaitForSeconds(_destroyDeley);
        _spawner.ActicivateRandomTarget();       
        gameObject.SetActive(false);
    }

   
}

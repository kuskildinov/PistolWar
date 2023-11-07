using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageble
{
    private const float DestroyGameObjectDeley = 1f;

    [SerializeField] private float _maxHealth = 100f;    
    [SerializeField] private NavMeshAgent _navMeshAgent;    
    [SerializeField] private EnemyState _startState;
    [SerializeField] private Animator _animator;   
    [SerializeField] private ParticleSystem _startParticles;

    public EnemyState _currentState;
    public bool _isAlive;

    private ITargetable _target;
    private Health _health;

    private void Update()
    {
        if (_isAlive)
        {
            StateChanged(_currentState);
        }
    }
    
    public void Initialize(ITargetable target)
    {
        _startParticles.Play();
        _isAlive = true;
        _target = target;
        _health = new Health(_maxHealth);
        _health.Die += OnDied;       
        _currentState = _startState;
        _navMeshAgent.SetDestination(_target.Position);       
    }

    public void TakeDamage(float damage)
    {
        _health.Decrease(damage);
        _currentState = EnemyState.TAKEDAMAGE;
    }


    private void StateChanged(EnemyState state)
    { 
        switch (state)
        {
            case EnemyState.IDLE:
                    {
                        _animator.SetInteger("state", 0);
                        break;
                    }
            case EnemyState.WALK:
                    {
                        _navMeshAgent.Resume();
                        _navMeshAgent.SetDestination(_target.Position);
                        _animator.SetInteger("state", 1);

                        break;
                    }
            case EnemyState.SHOOT:
                    {
                        _navMeshAgent.Stop();
                        transform.LookAt(_target.Position);
                        _animator.SetInteger("state", 2);
                        break;
                    }
            case EnemyState.TAKEDAMAGE:
                    {
                        _animator.SetInteger("state", 3);
                        break;
                    }
        }
        
    }
   
    private void OnDied()
    {        
        _isAlive = false;
        _animator.SetInteger("state", 4);        
        StartCoroutine(DeleyDestroy());
    }

    private void Deactivate()
    {
        _health.Die -= OnDied;
        gameObject.SetActive(false);
        StopCoroutine(DeleyDestroy());
    }

    private IEnumerator DeleyDestroy()
    {
        yield return new WaitForSecondsRealtime(DestroyGameObjectDeley);
        Deactivate();        
    }

}

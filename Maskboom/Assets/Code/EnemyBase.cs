using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour, IEnemy, IDamageable
{
    public event Action OnDied;
    public float Health => _health;

    [SerializeField] private float _health;

    private NavMeshAgent _agent;

    private Coroutine _moveCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform targetPosition)
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

         _moveCoroutine = StartCoroutine(Move(targetPosition));
    }

    private IEnumerator Move(Transform target)
    {
        while (true)
        {
            _agent?.SetDestination(target.position);
            yield return null;
        }
    }

    
    public void SetDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);

            OnDied?.Invoke();
        }
    }
}

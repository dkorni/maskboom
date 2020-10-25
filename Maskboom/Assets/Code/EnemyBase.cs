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

    [SerializeField] private float _damage;

    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay;

    private PlayerController _target;

    private NavMeshAgent _agent;

    private Coroutine _moveCoroutine;

    private bool _isAtack;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_target != null && !_isAtack)
        {
            var dist = Vector3.Distance(transform.position, _target.transform.position);
            if (dist <= _attackDistance)
            {
                StartCoroutine(Attack(_target));
                _isAtack = true;
            }
        }
    }

    public void SetTarget(Transform targetPosition)
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

         _moveCoroutine = StartCoroutine(Move(targetPosition));
         _target = targetPosition.GetComponent<PlayerController>();
    }

    public IEnumerator Attack(IDamageable target)
    {
        while (target.Health-_damage > 0)
        {
            target.SetDamage(_damage);

            // todo make some delay for animations before attack
            yield return new WaitForSeconds(_attackDelay);
        }

        target.SetDamage(_damage);
        _isAtack = false;
    }

    private IEnumerator Move(Transform target)
    {
        while (target != null)
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

            GameManager.Instance.Kills += 1;

            OnDied?.Invoke();
        }
    }
}

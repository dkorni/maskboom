using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour, IEnemy, IDamageable
{
    public event Action OnDied;
    public float Health => _health;

    [SerializeField] private float _health;

    [SerializeField] private float _damage;

    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay;

    [SerializeField]
    private Animator _animator;

    private PlayerController _target;

    private NavMeshAgent _agent;

    private Coroutine _moveCoroutine;

    private bool _isAtack;

    private string[] _attackStates = new[] {"Attack_HookLeft", "Attack_HookRight"};

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

    public virtual IEnumerator Attack(IDamageable target)
    {
        var state = _attackStates[Random.Range(0, 2)];

        _animator.SetTrigger(state);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length / 2);

        var dist = Vector3.Distance(transform.position, _target.transform.position);
        if (dist <= _attackDistance)
        {
            AudioManager.Instance.PlayRandomPunch();
            target.SetDamage(_damage);
        }

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length / 2);

        _isAtack = false;
    }

    private IEnumerator Move(Transform target)
    {
        while (target != null)
        {
            _agent?.SetDestination(target.position);
            _animator.SetBool("isMove", true);
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

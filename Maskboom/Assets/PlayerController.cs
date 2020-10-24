using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    [SerializeField]
    public BaseGun Gun;

    [SerializeField]
    private float _speed;

    [SerializeField] private float _health;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Gun.Shoot();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Gun.StopShoot();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0,  vertical) * _speed*Time.deltaTime;

        var mousePos = Input.mousePosition;

        // player position on the screen
        var playerPos = Camera.main.WorldToScreenPoint(transform.position);

        // direction ro mouse position
        var dir = mousePos - playerPos;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        _rigidbody.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        _rigidbody.MovePosition(transform.position + direction);
    }

    public event Action OnDied;
    public float Health => _health;
    public void SetDamage(float damage)
    {
        _health -= damage;

        UiManager.Instance.UpdateHealthBar(_health);

        if (_health <= 0)
        {
            OnDied?.Invoke();
            Destroy(gameObject);
        }
    }
}

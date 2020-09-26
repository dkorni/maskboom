using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour, IGun
{
    [SerializeField]
    protected GameObject _bullet;

    [SerializeField]
    protected Transform _bulletSpawn;

    [SerializeField]
    protected float _damage;

    [SerializeField] protected float _force;

    private Coroutine _shootingProcess;

    public void Shoot()
    {
        _shootingProcess = StartCoroutine(ShootProcess());
    }

    public void StopShoot()
    {
        if(_shootingProcess != null)
            StopCoroutine(_shootingProcess);
    }

    protected virtual IEnumerator ShootProcess()
    {
        var bulletGo = Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);

        var bullet = bulletGo.GetComponent<Bullet>();
        bullet.Damage = _damage;

        Destroy(bullet.gameObject, 1.5f);

        var bulletRb = bulletGo.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * _force, ForceMode.Impulse);

        yield return null;
    }
}
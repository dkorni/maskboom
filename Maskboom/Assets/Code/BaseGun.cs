using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour, IGun
{
    public int MaxAmmo
    {
        get { return _maxAmmo; }
    }

    [SerializeField]
    protected GameObject _bullet;

    [SerializeField]
    protected Transform _bulletSpawn;

    [SerializeField]
    protected float _damage;

    [SerializeField] protected int _currentAmmo;

    [SerializeField] protected int _maxAmmo;

    [SerializeField] protected float _force;

    protected AudioSource _audioSource;

    [SerializeField] protected AudioClip _shootClip;

    private Coroutine _shootingProcess;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
        UiManager.Instance.UpdateAmmoText(_currentAmmo);
    }

    public void Shoot()
    {
        if (_currentAmmo > 0)
        {
            _shootingProcess = StartCoroutine(ShootProcess());

            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();

            _audioSource.PlayOneShot(_shootClip);

            _currentAmmo -= 1;
            UiManager.Instance.UpdateAmmoText(_currentAmmo);
        }
    }

    public void StopShoot()
    {
        if(_shootingProcess != null)
            StopCoroutine(_shootingProcess);
    }

    public void AddAmmo(int ammo)
    {
        _currentAmmo = Mathf.Min(MaxAmmo, _currentAmmo + ammo);
        UiManager.Instance.UpdateAmmoText(_currentAmmo);
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
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage { get; set; }

    private void OnCollisionEnter(Collision col)
    {
        var enemy = col.transform.GetComponent<IEnemy>();
        if (enemy != null)
        {
            var damageable = col.transform.GetComponent<IDamageable>();
            damageable.SetDamage(Damage);
            Debug.Log($"Player hitted enemy {col.transform.name}");
        }
    }
}

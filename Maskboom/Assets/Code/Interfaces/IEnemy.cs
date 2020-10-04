using System.Collections;
using System.Collections.Generic;
using Assets.Code.Interfaces;
using UnityEngine;

interface IEnemy
{
    void SetTarget(Transform targetPosition);

    IEnumerator Attack(IDamageable target);
}

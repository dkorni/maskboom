using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemySpawner 
{
    float MinRadius { get; }
    float MaxRadius { get; }

    void StartSpawn();

    void StopSpawn();

    void UpdateTime(float fragCoef);

    void UpdateSpeed(float fragCoef);

    void UpdateRadius(float fragCoef);

    void UpdateAmount(float fragCoef);

    void MaxEnemies(int enemyCount);
}

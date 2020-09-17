using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    [SerializeField] protected List<GameObject> _enemyPrefabs;

    [SerializeField] private float _minTime = 3;
    [SerializeField] private float _maxTime =5;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;

    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;

    private Coroutine _processCoroutine;

    private float _nextTimeToSpawn;

    public void StartSpawn()
    {
        RandomizeNextTime();
        _processCoroutine = StartCoroutine(SpawnProcess());
    }

    public void StopSpawn()
    {
        StopCoroutine(_processCoroutine);
    }

    public void UpdateTime(float fragCoef)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateSpeed(float fragCoef)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateRadius(float fragCoef)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateAmount(float fragCoef)
    {
        throw new System.NotImplementedException();
    }

    protected IEnumerator SpawnProcess()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_nextTimeToSpawn);
            RandomizeNextTime();
        }
    }

    protected virtual void SpawnEnemy()
    {
        // todo
    }

    private void RandomizeNextTime()
    {
        Random.InitState((int)Time.time);

        _nextTimeToSpawn = Random.Range(_minTime, _maxTime);
    }
}

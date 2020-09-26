using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    public PlayerController Player;

    [SerializeField] protected List<GameObject> _enemyPrefabs;

    [SerializeField] private float _minTime = 3;
    [SerializeField] private float _maxTime =5;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;

    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;

    [SerializeField] private int _maxEnemies = 10;

    [SerializeField] private int _currentEnemies;

    private Coroutine _processCoroutine;

    private float _nextTimeToSpawn;

    public float MinRadius => _minRadius;

    public float MaxRadius => _maxRadius;

    void Start()
    {
        StartSpawn();
    }

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

    public void MaxEnemies(int enemyCount)
    {
        _maxEnemies = enemyCount;
    }

    protected IEnumerator SpawnProcess()
    {
        while (true)
        {
            if (_currentEnemies < _maxEnemies)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_nextTimeToSpawn);
                RandomizeNextTime();
            }

            yield return null;
        }
    }

    protected virtual void SpawnEnemy()
    {
        // todo
        var angle = Random.Range(0, 360);
        var radius = Random.Range(_minRadius, _maxRadius);
        var x = Math.Cos(angle) * radius + Player.transform.position.x;
        var y = Player.transform.position.y;
        var z = Math.Sin(angle) * radius + Player.transform.position.z;

        // todo check collisions with other objects and scene

        var point = new Vector3((float)x,y,(float)z);
        Debug.Log(point);

        var prefabToSpawn = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count - 1)];
        var enemyGo = Instantiate(prefabToSpawn, point, Quaternion.identity);

        var enemy = enemyGo.GetComponent<EnemyBase>();
        enemy.SetTarget(Player.transform);
        enemy.OnDied += () =>
        {
            _currentEnemies -= 1;
            GameManager.Instance.KillCoefficient += Constants.KillExp;
        };


        _currentEnemies++;
    }

    private void RandomizeNextTime()
    {
        _nextTimeToSpawn = Random.Range(_minTime, _maxTime);
    }
}

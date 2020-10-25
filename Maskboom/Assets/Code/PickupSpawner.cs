using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour
{
    public PlayerController Player;

    private const int MinAmmoCount = 5;

    [SerializeField] private GameObject _ammoBoxPrefab;

    [SerializeField] private GameObject _healBoxPrefab;

    [SerializeField] private float _maxAmmoPickups;

    [SerializeField] private float _maxHealPickups;

    [SerializeField] private float _ammoOffset;

    [SerializeField] private float _ammoHeight;

    public void UpdateAmmoPickups(float complexity)
    {
        _maxAmmoPickups = GameMath.CalculateLogarithmicComplexity(complexity, _ammoOffset, _ammoHeight);
    }

    private void Start()
    {
        StartCoroutine(SpawnAmmo());
        StartCoroutine(SpawnHealBoxes());
    }

    IEnumerator SpawnHealBoxes()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {

            if (GameManager.Instance.HealBoxCount < _maxHealPickups)
            {
                var pickupSpawnPosition = GetRandomPosition(Constants.MIN_SPAWN_DISTANCE, 30);

                var ammoPickup = Instantiate(_healBoxPrefab, pickupSpawnPosition, Quaternion.identity);

                Debug.DrawRay(pickupSpawnPosition, Vector3.up, Color.green, 5);

                GameManager.Instance.HealBoxCount++;
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 3));
        }
    }

    IEnumerator SpawnAmmo()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {

            if (GameManager.Instance.AmmoBoxCount < _maxAmmoPickups)
            {
                var pickupSpawnPosition = GetRandomPosition(Constants.MIN_SPAWN_DISTANCE, 30);

                var ammoPickup = Instantiate(_ammoBoxPrefab, pickupSpawnPosition, Quaternion.identity);

                Debug.DrawRay(pickupSpawnPosition, Vector3.up, Color.green, 5);

                GameManager.Instance.AmmoBoxCount++;
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 3));
        }
    }

    private Vector3 GetRandomPosition(float minRadius, float maxRadius)
    {
        for (int i = 0; i < 100; i++)
        {
            // select random angle
            int angle = Random.Range(1, 360);

            float x = Mathf.Cos(angle);
            float z = Mathf.Sin(angle);

            float radius = Random.Range(minRadius, maxRadius);

            var position = new Vector3(x * radius, 0, z * radius);
            position = Player.transform.position + position;

            // check that position is on nav mesh
            if (NavMesh.SamplePosition(position, out var hit, 1.0f, NavMesh.AllAreas))
                return position;
        }

        return Vector3.one;
    }
}

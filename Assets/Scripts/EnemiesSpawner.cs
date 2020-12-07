﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_interval));
    }

    private IEnumerator SpawnEnemy(float interval)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(interval);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_template, _spawnPoints[i].position, Quaternion.identity);

            if (i == _spawnPoints.Length - 1) i = -1;

            yield return waitForSeconds;
        }
    }
}

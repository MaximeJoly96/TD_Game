using UnityEngine;
using TD_Game.Entities;
using System;

namespace TD_Game.Systems
{
    public class EnemySpawner : MonoBehaviour
    {
        private const float SPAWN_DELAY = 1.0f;

        [SerializeField]
        private EnemyBehaviour _enemyPrefab;
        [SerializeField]
        private Transform[] _spawnPositions;
        [SerializeField]
        private Transform _enemyParent;

        private System.Random _rng;
        private float _spawnTimer;
        private TurretBehaviour[] _turrets;

        private void Awake()
        {
            _rng = new System.Random();
            _turrets = FindObjectsOfType<TurretBehaviour>();
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if(_spawnTimer > SPAWN_DELAY)
            {
                EnemyBehaviour enemy = Instantiate(_enemyPrefab, _enemyParent);
                enemy.transform.position = _spawnPositions[_rng.Next(_spawnPositions.Length)].position;

                enemy.Init(_turrets[_rng.Next(_turrets.Length)].transform);
                _spawnTimer = 0.0f;
            }
        }
    }
}

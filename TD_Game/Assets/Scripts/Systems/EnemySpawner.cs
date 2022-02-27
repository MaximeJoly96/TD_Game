using UnityEngine;
using TD_Game.Entities;
using System.Collections.Generic;
using System.Linq;

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
        private List<TurretBehaviour> _turrets;

        private void Awake()
        {
            _rng = new System.Random();
            _turrets = FindObjectsOfType<TurretBehaviour>().ToList();

            for (int i = 0; i < _turrets.Count; i++)
                _turrets[i].TurretDestroyed.AddListener(TurretHit);
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if(_spawnTimer > SPAWN_DELAY && _turrets.Count > 0)
            {
                EnemyBehaviour enemy = Instantiate(_enemyPrefab, _enemyParent);
                enemy.transform.position = _spawnPositions[_rng.Next(_spawnPositions.Length)].position;

                enemy.Init(_turrets[_rng.Next(_turrets.Count)].transform);
                _spawnTimer = 0.0f;
            }
        }

        private void TurretHit(GameObject turret)
        {
            _turrets.Remove(turret.GetComponent<TurretBehaviour>());
        }
    }
}

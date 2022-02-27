using UnityEngine;
using TD_Game.Entities;
using System.Linq;
using System.Collections.Generic;

namespace TD_Game.Systems
{
    public class GameManager : MonoBehaviour
    {
        private List<TurretBehaviour> _turrets;

        private void Awake()
        {
            _turrets = FindObjectsOfType<TurretBehaviour>().ToList();

            for (int i = 0; i < _turrets.Count; i++)
            {
                _turrets[i].TurretDestroyed.AddListener(TurretHit);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < _turrets.Count; i++)
                {
                    _turrets[i].CreateProjectile();
                }
            }
        }

        private void TurretHit(GameObject turret)
        {
            _turrets.Remove(turret.GetComponent<TurretBehaviour>());

            if (_turrets.Count == 0)
                Debug.Log("Game over");
        }
    }
}

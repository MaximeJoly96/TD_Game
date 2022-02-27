using UnityEngine;
using TD_Game.Entities;
using System.Linq;

namespace TD_Game.Systems
{
    public class GameManager : MonoBehaviour
    {
        private TurretBehaviour[] _turrets;

        private void Awake()
        {
            _turrets = FindObjectsOfType<TurretBehaviour>();

            for (int i = 0; i < _turrets.Length; i++)
            {
                _turrets[i].TurretDestroyed.AddListener(TurretHit);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < _turrets.Length; i++)
                {
                    _turrets[i].CreateProjectile();
                }
            }
        }

        private void TurretHit(GameObject turret)
        {
            int i = 0;
            for (i = 0; i < _turrets.Length && _turrets[i] != turret; i++) ;

            if (i < _turrets.Length)
                _turrets[i] = null;

            if (_turrets.Any(t => t != null))
                Debug.Log("Game over");
        }
    }
}

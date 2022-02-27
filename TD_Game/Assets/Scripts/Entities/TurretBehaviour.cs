using UnityEngine;
using TD_Game.Utils;
using UnityEngine.Events;
using TD_Game.Systems;

namespace TD_Game.Entities
{
    public class TurretBehaviour : MonoBehaviour
    {
        [SerializeField]
        private ProjectileBehaviour _projectilePrefab;

        private TurretDestroyedEvent _turretDestroyed;
        public TurretDestroyedEvent TurretDestroyed
        {
            get
            {
                if (_turretDestroyed == null)
                    _turretDestroyed = new TurretDestroyedEvent(gameObject);

                return _turretDestroyed;
            }
        }

        public void CreateProjectile()
        {
            ProjectileBehaviour proj = Instantiate(_projectilePrefab, transform);
            Plane plane = new Plane(transform.position, new Vector3(1.0f, transform.position.y, 1.0f), new Vector3(-1.0f, transform.position.y, -1.0f));
            Vector3 targetPosition = CameraExtensions.ScreenPointToWorld(Input.mousePosition, plane, Camera.main);
            proj.Init(targetPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();

            if (enemy)
            {
                TurretDestroyed.Invoke(gameObject);
                Destroy(enemy.gameObject);
                Destroy(gameObject);
            }  
        }
    }
}

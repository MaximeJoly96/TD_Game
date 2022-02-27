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
        [SerializeField]
        private Transform _canon;

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
            proj.Init(CursorUtils.MousePositionToWorld(transform.position));
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

        private void Update()
        {
            Vector3 target = CursorUtils.MousePositionToWorld(transform.position);
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}

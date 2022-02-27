using UnityEngine;

namespace TD_Game.Entities
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private const float SPEED = 3.0f;

        private Transform _target;
        private Vector3 _direction;

        public void Init(Transform target)
        {
            _target = target;
            _direction = (target.transform.position - transform.position).normalized;
        }

        private void Update()
        {
            Vector3 newPos = transform.localPosition + _direction * Time.deltaTime * SPEED;
            newPos.y = 0.5f;
            transform.localPosition = newPos;
        }

        private void OnTriggerEnter(Collider other)
        {
            ProjectileBehaviour projectile = other.GetComponent<ProjectileBehaviour>();

            if (projectile)
            {
                Destroy(projectile.gameObject);
                Destroy(gameObject);
            } 
        }
    }
}

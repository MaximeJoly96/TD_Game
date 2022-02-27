using UnityEngine;

namespace TD_Game.Entities
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        private const float SPEED = 10.0f;
        private const float MAX_DISTANCE = 30.0f;

        private Vector3 _direction;
        private bool _moving;

        public void Init(Vector3 targetPosition)
        {
            _direction = (targetPosition - transform.position).normalized;
            _direction.y = transform.position.y;
            _moving = true;
        }

        private void Update()
        {
            if(_moving)
            {
                transform.localPosition += new Vector3(_direction.x, 0.0f, _direction.z) * Time.deltaTime * SPEED;
            }

            if (Mathf.Abs(transform.position.x) > MAX_DISTANCE || Mathf.Abs(transform.position.z) > MAX_DISTANCE)
                Destroy(gameObject);
        }
    }
}

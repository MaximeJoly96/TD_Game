using UnityEngine.Events;
using UnityEngine;

namespace TD_Game.Systems
{
    public class TurretDestroyedEvent : UnityEvent<GameObject>
    {
        public GameObject Target { get; set; }

        public TurretDestroyedEvent(GameObject target)
        {
            Target = target;
        }
    }
}

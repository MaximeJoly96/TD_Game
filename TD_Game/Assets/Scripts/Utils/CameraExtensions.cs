using UnityEngine;

namespace TD_Game.Utils
{
    public static class CameraExtensions
    {
        public static Vector3 ScreenPointToWorld(Vector2 screenPoint, Plane plane, Camera camera)
        {
            Ray ray = camera.ScreenPointToRay(screenPoint);
            float distance;
            plane.Raycast(ray, out distance);

            return ray.GetPoint(distance);
        }
    }
}

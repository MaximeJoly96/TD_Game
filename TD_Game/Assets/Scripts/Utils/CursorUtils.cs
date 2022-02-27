using UnityEngine;

namespace TD_Game.Utils
{
    public static class CursorUtils
    {
        public static Vector3 MousePositionToWorld(Vector3 referencePosition)
        {
            Plane plane = new(referencePosition, new Vector3(1.0f, referencePosition.y, 1.0f), new Vector3(-1.0f, referencePosition.y, -1.0f));
            Vector3 targetPosition = CameraExtensions.ScreenPointToWorld(Input.mousePosition, plane, Camera.main);

            return targetPosition;
        }
    }
}

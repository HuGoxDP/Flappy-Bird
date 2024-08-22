using UnityEngine;

namespace _Scripts.Utils
{
    public static class UtilsClass
    {
        public static Vector3 GetMouseWorldPosition() {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        
        public static Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }


        public static Vector3 DirectionToMouse(Vector3 from)
        {
           return DirectionTo(from, GetMouseWorldPositionWithZ());
        }
        public static Vector3 DirectionToMouse(Vector3 from, Camera camera)
        {
            return DirectionTo(from, GetMouseWorldPositionWithZ(camera));
        }
        public static Vector3 DirectionTo(Vector3 from, Vector3 target)
        {
            var heading = target - from;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            return direction;
        }
        
        
        
        
        
        
        
        
        
    }
}
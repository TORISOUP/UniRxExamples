using UnityEngine;

namespace UniRxExamples
{
    public static class Vecator3Extensions
    {
        public static Vector3 SetX(this Vector3 vec, float value)
        {
            return new Vector3(value, vec.y, vec.z);
        }

        public static Vector3 SetY(this Vector3 vec, float value)
        {
            return new Vector3(vec.x, value, vec.z);
        }

        public static Vector3 SetZ(this Vector3 vec, float value)
        {
            return new Vector3(vec.x, vec.y, value);
        }
    }
}
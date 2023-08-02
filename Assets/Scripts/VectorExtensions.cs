using UnityEngine;

public static class VectorExtensions
{
    public static float DistanceTo(this Vector3 a, Vector3 b) => Vector3.Distance(a, b);
}

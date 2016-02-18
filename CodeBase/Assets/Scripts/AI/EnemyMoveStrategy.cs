using UnityEngine;
using System.Collections;

public class EnemyMoveStrategy : MonoBehaviour 
{
    public virtual Vector3 GetVelocity() { return Vector3.zero; }
    public virtual Quaternion GetRotation() { return Quaternion.identity; }

    public virtual float GetYOffset() { return 0.0f; }
}

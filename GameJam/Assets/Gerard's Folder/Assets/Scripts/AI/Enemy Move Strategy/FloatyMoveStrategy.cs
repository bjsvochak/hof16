using UnityEngine;
using System.Collections;

public class FloatyMoveStrategy : EnemyMoveStrategy
{
    public float intervalSize;

    private float t;
    private float yOffset;

    bool movingUpwards;

    void Start()
    {
        yOffset = 0.0f;
        t = 0.0f;
    }

    void FixedUpdate()
    {
        t += Time.deltaTime;
    }
    public override Vector3 GetVelocity()
    {
        return transform.up * (Mathf.Cos(t) * intervalSize); ;
    }
}

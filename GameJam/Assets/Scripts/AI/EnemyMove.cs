using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    // nodes
    public Transform[] nodes;
    private int next;

    // physics
    public float standardSpeed = 120.0f;
    public float rotationSpeed = 2.0f;
    private Rigidbody rb;
    public float midpoint;

    // settings
    public float threshold = 1.0f;  // how far from waypoint must we get before it is considered reached

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = nodes[0].position;
        next = 1;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // need strategy for reaching end of waypoint
        if (next >= nodes.Length)
            return;

        Vector3 direction = nodes[next].position - transform.position;

        if (direction.magnitude <= threshold)
        {
            direction = nodes[++next].position - transform.position;
        }

        float speed = standardSpeed;       

        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1.0f / rotationSpeed);
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}

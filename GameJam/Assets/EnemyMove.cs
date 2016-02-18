using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    // player reference for passby
    public Transform player;

    // nodes
    public Transform[] nodes;
    private int nextPatrol;

    // physics
    public float speed = 1200.0f;
    public float rotationWidth = 2.0f;
    private Rigidbody rb;

    // flags
    private bool isCircling;

    // settings
    public float threshold = 5.0f;  // how far from waypoint must we get before it is considered reached
    public float playerDistanceThreshold = 5.0f;
    public float secondsCircling = 20.0f;
    public float circlingYOffset = 200.0f; // how far above the player the enemies should be circling;
    public Vector3 circlingScale;
    public float keepBearingsWhileCircling = 1.0f;
    

    private PooledObject pooledObject;

    private Quaternion randomRotation;
    private Quaternion addedRotation;

    private Vector3 flyAwayDirection;

    private float keepBearingsTimer;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pooledObject = GetComponent<PooledObject>();
    }

    public void Reset()
    {
        transform.position = nodes[0].position;
        nextPatrol = 1;
        randomRotation = addedRotation = Quaternion.identity;
        flyAwayDirection = Vector3.zero;
        isCircling = false;
    }

    public void Start()
    {
        Reset();
    }

    void Update()
    {
        // patrolling, flying to player, passing by, then flying away
        if (flyAwayDirection != Vector3.zero)
            FlyAway();
        if (nextPatrol < nodes.Length)
            Patrol();
        else
            MoveTowardsPlayer();
    }

    void Patrol()
    {
        Vector3 direction = nodes[nextPatrol].position - transform.position;

        // go to the next node if we are now within range
        if (direction.magnitude <= threshold)
        {

            // if next node doesn't exist, start the first PassBy
            if(++nextPatrol >= nodes.Length)
            {
                GetRandomRotation();
                MoveTowardsPlayer();              
                return;
            }

            // node exists, so continue on to another node
            direction = nodes[nextPatrol].position - transform.position;            
        }

        MoveShip(direction);
    }

    void FlyAway()
    {
        MoveShip(flyAwayDirection);
    }

    IEnumerator FlyAwayRoutine()
    {
        yield return new WaitForSeconds(secondsCircling);
        Vector3 playerDir = player.transform.position - transform.position;

        // set the fly away direction so a random Vector3 away from the player
        do
            flyAwayDirection = Random.insideUnitSphere;
        while (Vector3.Dot(playerDir, flyAwayDirection) > 0);

        addedRotation = Quaternion.identity;

        yield return new WaitForSeconds(30.0f);

        Reset();
        pooledObject.ObjectPool.ReturnObject(gameObject);
    }

    void GetRandomRotation()
    {
        randomRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        randomRotation *= Quaternion.Euler(Random.Range(0.0f, 360.0f), 0.0f, 0.0f);
    }

    void MoveTowardsPlayer()
    {
        Vector3 playerPos = player.position;
        playerPos.y += circlingYOffset;

        Vector3 direction = playerPos - transform.position;

        float circlingMagnitude = Vector3.Scale(direction, circlingScale).magnitude;

        keepBearingsTimer -= Time.deltaTime;
        if (circlingMagnitude < playerDistanceThreshold) //threshold is distance you want circle strafing to start
        {
            if (!isCircling)
            {
                isCircling = true;
                StartCoroutine(FlyAwayRoutine());
            }
            addedRotation = randomRotation;
            keepBearingsTimer = keepBearingsWhileCircling;
        }
        else if (keepBearingsTimer <= 0.0f)
        {
            addedRotation = Quaternion.identity;
        }

        MoveShip(direction);
    }

    void MoveShip(Vector3 _direction)
    {
        _direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(_direction);
        rotation *= addedRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime / rotationWidth);
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

}

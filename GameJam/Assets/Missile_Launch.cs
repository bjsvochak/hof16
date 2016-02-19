using UnityEngine;
using System.Collections;

public class Missile_Launch : MonoBehaviour
{

    private GameObject Player;
    private Transform Mytrans;
    public GameObject rocket;
    public float MaxDistance;

    public float RateofFire = 5.0f;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Mytrans = GetComponent<Transform>();
        MaxDistance = 1000;


    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(Mytrans.position, Player.transform.position) < MaxDistance)
            RateofFire -= Time.deltaTime;

        if (RateofFire <= 0)
        {
            GameObject projectile = (GameObject)Instantiate(rocket, this.transform.position + transform.forward * 15, this.transform.rotation) as GameObject;
            RateofFire = 5.0f;

        }

    }
}

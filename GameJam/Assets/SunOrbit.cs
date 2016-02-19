using UnityEngine;
using System.Collections;

public class SunOrbit : MonoBehaviour {

    //private float timer = 0;
    public Transform item;
    public int time;
	// Use this for initialization
	void Start () {
       

    }

    // Update is called once per frame
    void Update ()
    {
        transform.RotateAround(item.position, Vector3.up, time * Time.deltaTime);
    }


}

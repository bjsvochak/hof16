using UnityEngine;
using System.Collections;

public class SunSpawner : MonoBehaviour {

    public float timer = 0;
    public float delay = 60.0f;
    public GameObject Sun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Spawn();
	}

    void Spawn()
    {
        if (timer > delay)
        {
            Instantiate(Sun, transform.position, transform.rotation);
            timer = 0;
        }
        else
            timer+= Time.deltaTime;
    }
}

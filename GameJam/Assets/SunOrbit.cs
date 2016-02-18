using UnityEngine;
using System.Collections;

public class SunOrbit : MonoBehaviour {

    private float timer = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(new Vector3(200.0f, 0.0f, 0.0f));

    }

    // Update is called once per frame
    void Update ()
    {
        if (timer >= 80.0f)
        {
            Destroy(gameObject);
        }
        else
            timer += Time.deltaTime;
    }


}

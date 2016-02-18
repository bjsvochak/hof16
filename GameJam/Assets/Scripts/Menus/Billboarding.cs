using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Billboarding : MonoBehaviour {
   
    //Collider col;

	// Use this for initialization	}
	

	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
	}
}

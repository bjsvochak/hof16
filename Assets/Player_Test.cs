using UnityEngine;
using System.Collections;

public class Player_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = (GameObject)Instantiate(Resources.Load("Projectile"),this.transform.position + transform.forward * 2, this.transform.rotation) as GameObject;
            //projectile.GetComponent<Rigidbody>().AddForce(-transform.forward * projectile.GetComponent<Basic_Projectile>().m_fSpeed * Time.deltaTime);
            Debug.Log("Fired");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject missle = (GameObject)Instantiate(Resources.Load("Homing Projectile"),this.transform.position + transform.forward * 2, this.transform.rotation) as GameObject;
        }
	}
}

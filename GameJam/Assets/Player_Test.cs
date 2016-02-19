using UnityEngine;
using System.Collections;

public class Player_Test : MonoBehaviour
{

    public GameObject target;

    // Use this for initialization
    void Start()
    {
        target = null;
    }

    public void SetTarget(GameObject tar)
    {
        target = tar;
    }

    public void Deactivate()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = (GameObject)Instantiate(Resources.Load("Projectile"), this.transform.position + transform.forward * 2, this.transform.rotation) as GameObject;
            //projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectile.GetComponent<Basic_Projectile>().m_fSpeed * Time.deltaTime);
            Debug.Log("Fired");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (target)
            {
                GameObject missle = (GameObject)Instantiate(Resources.Load("Homing Projectile"), this.transform.position + transform.forward * 2, this.transform.rotation) as GameObject;
                missle.GetComponent<HomingMissle>().m_gTarget = target;
            }
        }
    }
}

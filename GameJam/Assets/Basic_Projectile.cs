using UnityEngine;
using System.Collections;

public class Basic_Projectile : MonoBehaviour {

	// Use this for initialization

    public float m_fSpeed;
    public float m_fLife;
    public Rigidbody m_rRidgidBody;

	void Start () {
	}

    public void Shoot(Vector3 direction)
    {
       // transform.LookAt(direction);
        Debug.Log("lookat");
    }
	
	// Update is called once per frame
	public virtual void Update () 
    {
        m_rRidgidBody.AddForce(transform.forward * m_fSpeed * Time.deltaTime);

        m_fLife -= Time.deltaTime;
        if (m_fLife <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDeath");
            Instantiate(Resources.Load("Elementals/Prefabs/Fire/Big Bang"), collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
    }
}

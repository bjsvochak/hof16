using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    public Rigidbody m_rRidgidBody;
    public float m_fDeathTimer;
    public bool isDead;

	// Use this for initialization
	void Start () {
        m_fDeathTimer = Random.Range(3.0f, 6.0f);
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            // effects
        }
	}

    void ApplyDeath()
    {
        isDead = true;
        //GetComponent<OtherScript>().enabled = false;
    }
}

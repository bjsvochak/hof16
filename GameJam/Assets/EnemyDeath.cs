using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    public Rigidbody m_rRidgidBody;
    public float m_fDeathTimer;
    public bool isDead;
    public AudioClip DeathSound;
    public AudioSource source;

	// Use this for initialization
	void Start () {
        m_fDeathTimer = Random.Range(3.0f, 6.0f);
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            Debug.Log("working");
           transform.Translate(transform.forward * 100 * Time.deltaTime);
            transform.Rotate(0, 0, 45);
        }
	}

    void ApplyDeath()
    {
        isDead = true;
        GetComponent<EnemyMove>().enabled = false;
        source.clip = DeathSound;
        source.Play();
        Destroy(gameObject,DeathSound.length);
    }
}

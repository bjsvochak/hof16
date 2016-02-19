using UnityEngine;
using System.Collections;


public class Missile_Update : MonoBehaviour {

    public GameObject Target;
    public float m_speed;
    public float rotationWidth;
    public float m_damage = 65;

    private Rigidbody rb;
    private CharacterController Controller;

    private Transform MyTrans;
    private Transform TarLoc;
	// Use this for initialization
	void Start () {
        MyTrans = GetComponent<Transform>();
        Controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("Player");
        TarLoc = Target.GetComponent<Transform>();
        m_speed = 1700;
        rotationWidth = 0.2f;

	}
	
	// Update is called once per frame
	void Update () {

        if(Target)
        {
            Vector3 Dir = TarLoc.position - MyTrans.position;
            Dir = Dir.normalized;

            MoveMissile(Dir);

        }
	
	}

    public void SetTarget(GameObject NewTarg)
    {
        Target = NewTarg;
        TarLoc = Target.GetComponent<Transform>();

    }

    void MoveMissile(Vector3 _direction)
    {
        _direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(_direction);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, Time.deltaTime / rotationWidth);
        rb.velocity = transform.forward * m_speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gameObject.SendMessage("ApplyDeath");

           collision.gameObject.GetComponent<RailUpdate>().m_Health -= m_damage;

            Instantiate(Resources.Load("Elementals/Prefabs/Fire/Big Bang"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

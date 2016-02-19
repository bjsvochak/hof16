using UnityEngine;
using System.Collections;
using System.Linq;
using UnityStandardAssets.Utility;

public class RailUpdate : MonoBehaviour {

  public GameObject[] NodeList;
  public GameObject[] BossNodeList;
  public GameObject DestinationNode;
  public Transform BossShip;
  public int CurrentIndex = 0;
  public int CurrentIndexBoss = 0;
  public int DebugLength;
  public float Speed = 20.0f;
  public float MomentumCap = 0.2f;
  public float Angle = 0;
  public bool Going = false;
  private Transform MyTrans;
  public Vector3 MoveDirection = Vector3.zero;
  public float rotationWidth = 2.0f;
  private RailUpdate Script;
  private Rigidbody rb;
  private AutoMoveAndRotate amar;
  private bool isFightingBoss = false;
  private Quaternion rightBarrel;
  public float barrelRollSpeed = 1;
  public float m_Health = 1000;

  CharacterController Controller;

	// Use this for initialization
	void Start () {
        Going = false;

        NodeList = GameObject.FindGameObjectsWithTag("TrackNode").OrderBy(gameObject => gameObject.name).ToArray<GameObject>();
      DebugLength = NodeList.GetLength(DebugLength);
       Controller = GetComponent<CharacterController>();
       CurrentIndex = 0;
       DestinationNode = NodeList[CurrentIndex];
       MyTrans = GetComponent<Transform>();
       rb = transform.parent.parent.GetComponent<Rigidbody>();
       amar = transform.parent.GetComponent<AutoMoveAndRotate>();
       rightBarrel = Quaternion.Euler(0.0f, 90.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.F10))
            Going = !Going;

        if (Going)
        {
            
            float M;
            MoveDirection = DestinationNode.transform.position - transform.parent.parent.position;
           // GetComponent<Transform>().Translate(MoveDirection.normalized * Speed * Time.deltaTime);
            
            //Controller.Move(MoveDirection.normalized * Speed * Time.deltaTime);
            MoveShip(MoveDirection);

            if(isFightingBoss)
                KeepBossInView();

            //MyTrans.localPosition += MoveDirection.normalized * Speed * Time.deltaTime;

            //Angle = Vector3.Angle( MoveDirection.normalized, MyTrans.forward.normalized);

            //if(Angle > 90)         
            //     M = MomentumCap;
            //else
            //{
            //    float R = Angle / 90;
            //    M = R * MomentumCap;
            //}

            //MyTrans.Rotate(MyTrans.up, M);


        }

        //2213
	}

    void KeepBossInView()
    {
        Vector3 bossDirection = BossShip.position - transform.parent.position;
        if (Vector3.Dot(transform.parent.up, bossDirection) < 0.1f)
        {
            amar.enabled = true;
        }
        else if (Vector3.Dot(transform.up, bossDirection) > 0.4f)
        {
            amar.enabled = false;
        }

        /*
        Vector3 bossDirection = BossShip.position - transform.parent.position;
        Vector3 bossDirectionLocal = transform.parent.InverseTransformVector(bossDirection);
        bossDirectionLocal.Scale(Vector3.ri);
        transform.parent.up = Vector3.Slerp(transform.parent.up, transform.parent.TransformVector(bossDirectionLocal), Time.deltaTime / rotationWidth);
        */
        /*
        Quaternion viewOrientation = Quaternion.LookRotation(BossShip.position - transform.parent.position);
        viewOrientation *= transform.parent.parent.rotation;
        transform.parent.rotation = viewOrientation;
        */
    }

    void MoveShip(Vector3 _direction)
    {
        _direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(_direction);

        transform.parent.parent.rotation = Quaternion.Slerp(transform.parent.parent.rotation, rotation, Time.deltaTime / rotationWidth);
        rb.velocity = transform.parent.parent.forward * Speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == DestinationNode)
        {
            if (++CurrentIndexBoss >= BossNodeList.Length)
                CurrentIndexBoss = 0;

            DestinationNode = BossNodeList[CurrentIndexBoss];
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject == DestinationNode)
        {

            if (CurrentIndex == DebugLength - 1)
            {
                //Run End Level Here
                //[

                if (col.gameObject.CompareTag("TrackNode"))
                {
                    DestinationNode = BossNodeList[0];
                    CurrentIndexBoss = 0;
                    Destroy(col.gameObject);
                    isFightingBoss = true;
                }
                else
                {
                    if (++CurrentIndexBoss >= BossNodeList.Length)
                        CurrentIndexBoss = 0;

                    DestinationNode = BossNodeList[CurrentIndexBoss];
                }

                
                //]
                /*
                Script = GetComponent<RailUpdate>();
                Script.enabled = false;
                 * */
            }
            else
            {
                CurrentIndex++;
                DestinationNode = NodeList[CurrentIndex];
                Destroy(col.gameObject);
            }


        }
    }
}

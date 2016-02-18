﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class RailUpdate : MonoBehaviour {

  public GameObject[] NodeList;
  public GameObject DestinationNode;
  public int CurrentIndex = 0;
  public int DebugLength;
  public float Speed = 20.0f;
  public float MomentumCap = 0.2f;
  public float Angle = 0;
  public bool Going = false;
  private Transform MyTrans;
  public Vector3 MoveDirection = Vector3.zero;
  private RailUpdate Script;

  CharacterController Controller;

	// Use this for initialization
	void Start () {


        NodeList = GameObject.FindGameObjectsWithTag("TrackNode").OrderBy(gameObject => gameObject.name).ToArray<GameObject>();
      DebugLength = NodeList.GetLength(DebugLength);
       Controller = GetComponent<CharacterController>();
       CurrentIndex = 0;
       DestinationNode = NodeList[CurrentIndex];
       MyTrans = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.F10))
            Going = !Going;

        if (Going)
        {
            
            float M;
            MoveDirection = DestinationNode.GetComponent<Transform>().position - MyTrans.position;
           // GetComponent<Transform>().Translate(MoveDirection.normalized * Speed * Time.deltaTime);
            Controller.Move(MoveDirection.normalized * Speed * Time.deltaTime);

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


	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject == DestinationNode)
        {

            if (CurrentIndex == DebugLength - 1)
            {
                //Run End Level Here
                //[




                //]
                Script = GetComponent<RailUpdate>();
                Script.enabled = false;
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

using UnityEngine;
using System.Collections;

public class DebugTurretLock : MonoBehaviour {

    public float MaxDistance;
    public AutoTurretLock[] ScriptList;

    private Ray Lazer;
    private Transform CamTrans;
    private Transform Mytrans;
    private RaycastHit hit;
    public AutoTurretLock FrontSys;
    public AutoTurretLock BackSys;
    public AutoTurretLock RightSys;
    public AutoTurretLock LeftSys;
    public bool Front;
    public bool  Right;
	// Use this for initialization
	void Start () {
        GameObject[] TurretList;
        CamTrans = Camera.main.GetComponent<Transform>();
        Mytrans = GetComponent<Transform>();
        Lazer = new Ray(CamTrans.position, CamTrans.forward.normalized);
        MaxDistance = 100.0f;
        TurretList = GameObject.FindGameObjectsWithTag("AutoTurret");

        BackSys = TurretList[0].GetComponent <AutoTurretLock>();
        FrontSys = TurretList[1].GetComponent<AutoTurretLock>();
        LeftSys = TurretList[2].GetComponent<AutoTurretLock>();
        RightSys = TurretList[3].GetComponent<AutoTurretLock>();

	}
	
	// Update is called once per frame
	void Update () {


        Lazer.origin = CamTrans.position;
        Lazer.direction = CamTrans.forward.normalized;
        Debug.DrawRay(Lazer.origin, Lazer.direction, Color.magenta);

      if(Physics.Raycast(Lazer, out hit, MaxDistance) && hit.collider.gameObject.tag == "Dummy")
      {


          Transform LockOn = hit.collider.gameObject.transform;


          float HalfX = Vector3.Dot(Mytrans.right, LockOn.position - Mytrans.position);
          float HalfY = Vector3.Dot(Mytrans.forward, LockOn.position - Mytrans.position);

          Front = HalfX < 0;
          Right = HalfY > 0;


          if (Front)
          {
              FrontSys.SetTarget(hit.collider.gameObject);
              BackSys.ResetTurret();
          }
          else
          {
              BackSys.SetTarget(hit.collider.gameObject);
             FrontSys.ResetTurret();
          }

          if (Right)
          {
              RightSys.SetTarget(hit.collider.gameObject);
              LeftSys.ResetTurret();
          }
          else
          {
              LeftSys.SetTarget(hit.collider.gameObject);
              RightSys.ResetTurret();
          }
      }


       
	}
}

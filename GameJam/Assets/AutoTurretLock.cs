using UnityEngine;
using System.Collections;

public class AutoTurretLock : MonoBehaviour {



    private Vector3 InitFacing;
    private Transform Mytrans;
    private Transform EnemyTransform;
    private GameObject Target;
    public float MomentumCap = 0.2f;
    public float RotateSpeed;
     public bool Reset;
	// Use this for initialization
	void Start () {
     
       Mytrans = GetComponent<Transform>();
       InitFacing = Mytrans.forward.normalized;
       Reset = true;
       RotateSpeed = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {

   
        float Angle = Vector3.Angle(Mytrans.forward.normalized, EnemyTransform.position);

        if (Angle > 1)
        {
            float M;
            if (Angle > 90)
                M = MomentumCap;
            else
            {
                float R = Angle / 90;
                M = R * MomentumCap;
            }

            Mytrans.Rotate(Mytrans.up, M);
        }
     

	
	}

    public void SetTarget(GameObject NewTarget)
    {
        Target = NewTarget;
        Reset = false;

        EnemyTransform = Target.GetComponent<Transform>();
    }

   public void ResetTurret()
    {
        Vector3 F = Mytrans.forward.normalized;
        Vector3 I = InitFacing.normalized;

        float A = Vector3.Angle(F, I);

        Mytrans.Rotate(Mytrans.up, A * RotateSpeed * Time.deltaTime);

        if (Mytrans.forward == InitFacing)
            Reset = true;


    }
}

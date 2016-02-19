using UnityEngine;
using System.Collections;

public class HomingMissle : Basic_Projectile {

    public GameObject m_gTarget;

	// Use this for initialization
	void Start () {
	}

    public void SetTarget(GameObject target)
    {
        m_gTarget = target;
    }
	
	// Update is called once per frame
	public void Update () 
    {
        if (!m_gTarget)
        {
            base.Update();
            return;
        }
        else
	    {
            //Vector3 dir = m_gTarget.transform.position - transform.position;
            transform.LookAt(m_gTarget.transform);
            m_rRidgidBody.AddForce(transform.forward * m_fSpeed * Time.deltaTime);
	    }
	}
}

using UnityEngine;
using System.Collections;

public class EnemyCombatBehavior : MonoBehaviour {

    EnemyShooting m_eGun;
    public float m_fShotCoolDown;
    private float m_fShotTimer;
    public GameObject m_gPlayer;

	// Use this for initialization
	void Start () {
        m_eGun = gameObject.GetComponent<EnemyShooting>();
        m_fShotTimer = m_fShotCoolDown;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_fShotTimer > 0)
        {
            m_fShotTimer -= Time.deltaTime;
        }
        else
        {
            Transform tempTrans = transform;
            tempTrans.LookAt(m_gPlayer.transform.position);
            m_eGun.Shoot(tempTrans);
            m_fShotTimer = m_fShotCoolDown;
        }
	}
}

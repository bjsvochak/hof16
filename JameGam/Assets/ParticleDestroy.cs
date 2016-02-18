using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

    private ParticleSystem ps;
    private float m_fDuration;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        m_fDuration = ps.duration;
	}
	
	// Update is called once per frame
	void Update () {
        if (ps)
        {
            m_fDuration -= Time.deltaTime;
            if (m_fDuration <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
}

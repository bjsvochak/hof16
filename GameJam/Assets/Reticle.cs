using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    Vector3 m_vViewCoords;
    public Camera m_cMainCamera;
    public GameObject[] EnemyList;
    public GameObject m_gCurrentTarget;
    public GameObject m_gReticle;
    public Image m_cImage;
    public Sprite m_cLockedOn;
    public Sprite m_cLockingOn;
    public Sprite m_cDefault;

    public float m_fLockOnResetValue;
    private float m_fLockOnTimer;

    public int tester1;
    public GameObject trigger;

    // Use this for initialization
    void Start()
    {
        m_gCurrentTarget = new GameObject();
        m_cImage.sprite = m_cDefault;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hitInfo;
        Ray ray = new Ray(m_gReticle.transform.position, m_gReticle.transform.forward);
        hitInfo = Physics.SphereCastAll(ray, 30.0f);
        bool foundOne = false;
        tester1 = 0;
        for (int i = 0; i < hitInfo.Length; i++)
        {
            tester1++;
            if (hitInfo[i].collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit");
                GameObject temp = hitInfo[i].collider.gameObject;
                Vector3 vecTo = temp.transform.position - m_gReticle.transform.position;
                Vector3 currentVecTo;
                float currentDistance;
                float tempDistance = vecTo.magnitude;

                foundOne = true;

                if (m_gCurrentTarget)
                {
                    currentVecTo = m_gCurrentTarget.transform.position - m_gReticle.transform.position;
                    currentDistance = currentVecTo.magnitude;
                    if (currentDistance > tempDistance)
                    {
                        m_gCurrentTarget = new GameObject();
                        m_gCurrentTarget = temp;
                    }
                }
                else
                {
                    m_gCurrentTarget = new GameObject();
                    m_gCurrentTarget = temp;
                }
            }
        }

        if (foundOne)
        {
            m_cImage.rectTransform.position = m_cMainCamera.WorldToScreenPoint(m_gCurrentTarget.transform.position);
            if (m_fLockOnTimer > 0)
            {
                m_cImage.sprite = m_cLockingOn;
                m_fLockOnTimer -= Time.deltaTime;
                trigger.SendMessage("Deactivate");
            }
            else
            {
                m_cImage.sprite = m_cLockedOn;
                trigger.SendMessage("SetTarget", m_gCurrentTarget);
            }
        }
        else
        {
            m_cImage.rectTransform.position = new Vector3((Screen.width * 0.5f) - 60.0f, Screen.height * 0.5f, 1);
            m_fLockOnTimer = m_fLockOnResetValue;
            m_cImage.sprite = m_cDefault;
            m_gCurrentTarget = null;
            trigger.SendMessage("Deactivate");
        }
    }
}

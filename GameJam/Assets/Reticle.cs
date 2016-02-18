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
    public GameObject closestTarget;


    public float m_fLockOnResetValue;
    private float m_fLockOnTimer;

    // Use this for initialization
    void Start()
    {
        EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        m_gCurrentTarget = new GameObject();
        closestTarget = new GameObject();
        closestTarget = EnemyList[0];
        m_cImage.sprite = m_cDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyList.Length <= 0)
        {
            return;
        }

        m_vViewCoords = m_cMainCamera.WorldToScreenPoint(m_gReticle.transform.position);


        for (int i = 0; i < EnemyList.Length; i++)
        {
            GameObject temp = EnemyList[i] as GameObject;

            Vector3 vecTo = temp.transform.position - m_gReticle.transform.position;


            if (Vector3.Dot(transform.right, vecTo) <= 0)
            {
                continue;
            }
            else if (closestTarget == null)
            {
                closestTarget = temp;
                continue;
            }

            Vector3 vecToClosest = closestTarget.transform.position - m_gReticle.transform.position;

            if (vecToClosest.magnitude > vecTo.magnitude)
            {
                closestTarget = temp;
            }

            Vector2 reticlePoint = new Vector2(m_vViewCoords.x, m_vViewCoords.y);
            Vector2 enemyPoint = new Vector2(closestTarget.transform.position.x, closestTarget.transform.position.y);
            enemyPoint = m_cMainCamera.WorldToScreenPoint(enemyPoint);

            float distance = Vector2.Distance(reticlePoint, enemyPoint);
            float distanceT;
            Vector2 currentTargetPoint;
            if (m_gCurrentTarget)
            {
                currentTargetPoint = new Vector2(m_gCurrentTarget.transform.position.x, m_gCurrentTarget.transform.position.y);
                currentTargetPoint = m_cMainCamera.WorldToScreenPoint(currentTargetPoint);
                distanceT = Vector2.Distance(reticlePoint, currentTargetPoint);
                if (distanceT > distance)
                {
                    m_gCurrentTarget = closestTarget;
                }
            }


            if (Vector3.Dot(transform.right, closestTarget.transform.position - m_gReticle.transform.position) <= 0)
            {
                m_gCurrentTarget = null;
                continue;
            }

            if (distance < 250.0f)
            {
                Debug.Log("ok");
                m_gCurrentTarget = closestTarget;
            }
            else
            {
                m_gCurrentTarget = null;
            }
        }

        if (m_gCurrentTarget == null)
        {
            m_cImage.rectTransform.position = new Vector3((Screen.width * 0.5f), Screen.height * 0.5f, 1);
            m_fLockOnTimer = m_fLockOnResetValue;
            m_cImage.sprite = m_cDefault;
        }
        else
        {
            m_cImage.rectTransform.position = m_cMainCamera.WorldToScreenPoint(m_gCurrentTarget.transform.position);
            if (m_fLockOnTimer > 0)
            {
                m_cImage.sprite = m_cLockingOn;
                m_fLockOnTimer -= Time.deltaTime;
            }
            else
            {
                m_cImage.sprite = m_cLockedOn;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class LTFirstPerson : MonoBehaviour
{

    [SerializeField]
    private Camera m_Camera = null;

    public float XSensitivity;
    public float YSensitivity;
    public float MaxX;
    public float MinX;
    public float yRot;
    public float xRot;
    public float SwivelRotation;
    public Quaternion m_CharacterTargetRot;
    public Quaternion m_CameraTargetRot;
    public Quaternion m_NozzleTargetRot;
    private GameObject Nozzle;
    private Transform MyTrans;
    private Transform MainC;
    private Transform NozTrans;
    private Transform World;

    // Use this for initialization
    void Start()
    {
        Nozzle = GameObject.FindGameObjectWithTag("CannonNozzle");
        MyTrans = GetComponent<Transform>();
        MainC = Camera.main.GetComponent<Transform>();
        NozTrans = Nozzle.GetComponent<Transform>();
        World = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
        XSensitivity = 4;
        YSensitivity = 4;
        MaxX = 0.25f;
        MinX = -0.07f;
        Init(MyTrans, MainC);
    }

    // Update is called once per frame
    void Update()
    {


        RotateView();
    }

    private void RotateView()
    {
        bool clamp = false;

        float A = Vector3.Angle(MyTrans.forward.normalized, MainC.forward.normalized);

        yRot = Input.GetAxis("Mouse X") * XSensitivity;
        xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        m_CharacterTargetRot *= Quaternion.Euler(0, yRot, 0);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0, 0);
        m_NozzleTargetRot *= Quaternion.Euler(xRot, 0, 0);

//        SwivelRotation = Vector3.Dot(World.right.normalized, MainC.transform.forward.normalized);
//       // LookRotation = Quaternion.Angle(Quaternion.LookRotation(MyTrans.right.normalized), m_NozzleTargetRot);

//        if (SwivelRotation < -0.5 &&SwivelRotation > 0.5)
//        else
//        {
//MyTrans.localRotation = Quaternion.Euler()
//        }


       // NozTrans.localRotation = m_NozzleTargetRot;
        MyTrans.localRotation = m_CharacterTargetRot;
        MainC.localRotation = m_CameraTargetRot;


    }

    public void Init(Transform character, Transform camera)
    {
        m_CharacterTargetRot = character.localRotation;
        m_CameraTargetRot = camera.localRotation;
        m_NozzleTargetRot = NozTrans.localRotation;
    }
}

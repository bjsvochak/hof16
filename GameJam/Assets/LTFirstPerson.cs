using UnityEngine;
using System.Collections;

public class LTFirstPerson : MonoBehaviour {

    [SerializeField]
    private Camera m_Camera = null;

    public float XSensitivity;
    public float YSensitivity;


    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;

   private Transform MyTrans;
   private Transform MainC;

	// Use this for initialization
	void Start () {
        MyTrans = GetComponent<Transform>();
        MainC = Camera.main.GetComponent<Transform>();

        XSensitivity = 4;
        YSensitivity = 4;
        Init(MyTrans, MainC);
	}
	
	// Update is called once per frame
	void Update () {

        
        RotateView();
	}

    private void RotateView()
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        m_CharacterTargetRot *= Quaternion.Euler(0, yRot, 0);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0, 0);

        MyTrans.localRotation = m_CharacterTargetRot;
        MainC.localRotation = m_CameraTargetRot;
    }

    public void Init(Transform character, Transform camera)
    {
        m_CharacterTargetRot = character.localRotation;
        m_CameraTargetRot = camera.localRotation;
    }
}

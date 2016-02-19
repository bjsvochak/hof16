using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public string[] Credits = null;
    private int currspot;
    public Vector3 RotationPosition = Vector3.zero;
    //public Transform RotationAxisObject = null;
    public float RotationAngle = 0.0f;
    public GameObject Ring = null;
    public GameObject RoleText = null; 

	// Use this for initialization
	void Start ()
    {
        currspot = 0;
        RoleText.GetComponent<Text>().text = Credits[currspot];
        GetComponent<Text>().text = Credits[currspot+=1];
        
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void FixedUpdate()
    {
        if (Ring)
        {
            //if (RotationAxisObject)
            //    Ring.GetComponent<RectTransform>().Rotate(RotationAxisObject.position, RotationAngle);
            //else
                Ring.GetComponent<Transform>().Rotate(RotationPosition, RotationAngle);
        }
        Ring.GetComponent<Transform>().Rotate(RotationPosition, RotationAngle);

    }

    void OnTriggerEnter(Collider other)
    {
        if (currspot < Credits.Length - 1)
        {
            currspot++;
            if (Credits[currspot] == "Game Design" || Credits[currspot].ToLower() == "programmers" || Credits[currspot].ToLower() == "audio" ||
                Credits[currspot].ToLower() == "artists" || Credits[currspot].ToLower() == "computer animations" || Credits[currspot].ToLower() == "vfx")
            {
                RoleText.GetComponent<Text>().CrossFadeAlpha(0.0f, 0.1f, true);
                RoleText.GetComponent<Text>().text = Credits[currspot];
                RoleText.GetComponent<Text>().CrossFadeAlpha(1.0f, 3.5f, false);

                currspot++;
            }
            GetComponent<Text>().text = Credits[currspot];
        }
        else
        {
            RoleText.GetComponent<Text>().text = " ";
            GetComponent<Text>().text = "\"Blank\"";
        }
    }
}

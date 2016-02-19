using UnityEngine;
using System.Collections;

public class pauseUI : MonoBehaviour {

    public static bool paused = false;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Canvas>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
            if (GetComponent<Canvas>().enabled)
            {
                Time.timeScale = 0.0f;
                paused = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                paused = false;
            }
        }
	}
}

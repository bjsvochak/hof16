using UnityEngine;
using System.Collections;

public class StorySlides : MonoBehaviour {

    public string firstslidetext;
    public string secondslidetext;
    public float delay = 5.0f;
    private float timer = 0;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        timer += Time.deltaTime;
	}
}

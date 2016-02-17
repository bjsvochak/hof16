using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVolume : MonoBehaviour {


	// Use this for initialization
	void Start () {

        if (gameObject.GetComponent<Slider>() == null)
            return;
        else
            GetComponent<Slider>().value = AudioListener.volume;
	}

    void Update()
    {
        AudioListener.volume = GetComponent<Slider>().value;
    }
}

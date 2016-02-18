using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonInputs : MonoBehaviour {


    public static void FadeToBlack()
    {
        GameObject.Find("Image").GetComponent<Image>().CrossFadeAlpha(0.0f, 2.0f, true);
    }

    public static void FadeBack()
    {
        GameObject.Find("Image").GetComponent<Image>().CrossFadeAlpha(1.0f, 2.0f, true);

    }
    // Use this for initialization
    void Start () {
        if (UnityEngine.VR.VRDevice.isPresent)
            Screen.fullScreen = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        //SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Fullscreen()
    {
        if(!UnityEngine.VR.VRDevice.isPresent)
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ExitGame()
    {
        
        Application.Quit();

        //Application.CancelQuit();
    }

   void OnTriggerEnter(Collider col)
    {
        FadeToBlack();
    }

    void OnTriggerExit(Collider col)
    {
        FadeBack();
    }
}

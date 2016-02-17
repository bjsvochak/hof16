using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SceneManagement;

public class ButtonInputs : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        //EditorSceneManager.OpenScene();
    }

    public void Options()
    {
        //EditorSceneManager.OpenScene();
    }

    public void Credits()
    {
        //EditorSceneManager.OpenScene();
    }

    public void ExitGame()
    {
        
        Application.Quit();

        //Application.CancelQuit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            SceneManager.UnloadSceneAsync("SampleScene");
            SceneManager.LoadSceneAsync("MainMenu");
            //SceneManager.UnloadSceneAsync("SampleScene");
        }
    }
}

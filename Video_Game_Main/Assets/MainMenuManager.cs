using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject blocker;
    // Start is called before the first frame update
    void Start()
    {
        blocker.SetActive(false);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
    }

    public void StartApp()
    {
        blocker.SetActive(true);
        SceneManager.LoadSceneAsync("SampleScene");
        Cursor.visible = false;
        //blocker.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

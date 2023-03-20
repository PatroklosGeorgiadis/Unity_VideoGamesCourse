using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAreaTitle : MonoBehaviour
{
    public TextMeshProUGUI title;
    public static UIAreaTitle Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMessage(string message)
    {
        title.gameObject.SetActive(true);
        title.text = message;
    }
}

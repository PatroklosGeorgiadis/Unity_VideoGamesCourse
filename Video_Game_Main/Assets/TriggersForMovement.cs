using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggersForMovement : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerTrigger;
    public GameObject bg, sender;
    public Image imgbg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIAreaTitle.Instance.ShowMessage(sender.name);
            imgbg.color = new Color32(10, 10, 10, 240);

            StartCoroutine(passiveMe(5));
            onPlayerTrigger.Invoke();
        }
    }
 
    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        UIAreaTitle.Instance.ShowMessage("");
        imgbg.color = new Color32(10, 10, 10, 0);
    }
}

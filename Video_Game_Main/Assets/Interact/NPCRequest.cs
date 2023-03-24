using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

//Version 1.2
//A class of a sign, it contains a message for display
public class NPCRequest : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject indicator;
    [TextArea(3,10)]
    public string text;
    public RawImage imgbg;
    [SerializeField] public TextMeshProUGUI textMesh;

    [SerializeField] private bool readyForCombat;
    [SerializeField] private GameObject NPCs;
    [SerializeField] private GameObject Spawners;
    [SerializeField] private GameObject sunDirection;
    [SerializeField] private GameObject getReadyScreen;
    [SerializeField] private GameObject Timer;
    [SerializeField] private TextMeshProUGUI Task;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnInteract(Interactor interactor){
        if (!readyForCombat)
        {
            if (animator != null)
            {
                animator.SetTrigger("Interacted");
            }

            indicator.SetActive(false); //hide
                                        //call interactor's public method ReceiveInteract
                                        //...with override method that gets a string as a parameter
                                        //interactor.ReceiveInteract(text);

            string[] dialog = text.Split("~");
            int secs = 0;
            foreach (var sentence in dialog)
            {
                StartCoroutine(DialogBoxorder(sentence, secs));
                secs = secs + 3;
            }
            StartCoroutine(passiveMe(secs));
            readyForCombat = true;
        }
        else
        {
            indicator.SetActive(false); //hide
                                        //call interactor's public method ReceiveInteract
                                        //...with override method that gets a string as a parameter
                                        //interactor.ReceiveInteract(text);

            readyForCombat = false;
            sunDirection.transform.Rotate(194.0f, -30.0f, 0.0f, Space.Self);
            getReadyScreen.SetActive(true);
            Task.text = "Defend the village";
            StartCoroutine(getReady());
        }
    }	
	
	//unimplemented Methods
    public void OnEndInteract()
    {
    }

    public void OnAbortInteract()
    {
		indicator.SetActive(false); //hide
    }

    public void OnReadyInteract()
    {
		indicator.SetActive(true); //show
    }

    IEnumerator getReady()
    {
        yield return new WaitForSeconds(3);
        Timer.SetActive(true);
        Spawners.SetActive(true);
        getReadyScreen.SetActive(false);
        NPCs.SetActive(false);
    }

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        textMesh.text = "";
        imgbg.color = new Color32(10, 10, 10, 0);
    }

    IEnumerator DialogBoxorder(string sentence, int secs)
    {
        yield return new WaitForSeconds(secs);
        textMesh.text = sentence;
        imgbg.color = new Color32(239, 239, 239, 255);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

//Version 1.2
//A class of a sign, it contains a message for display
public class NPCTalk : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject indicator;
    [TextArea(3,10)]
    public string text;
    public RawImage imgbg;
    [SerializeField] public TextMeshProUGUI textMesh;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnInteract(Interactor interactor){
        if (animator != null)
        {
            animator.SetTrigger("Interacted");
        }

        indicator.SetActive(false); //hide
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        //interactor.ReceiveInteract(text);

        textMesh.text = text;
        imgbg.color = new Color32(239, 239, 239, 255);
        StartCoroutine(passiveMe(5));
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

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        textMesh.text = "";
        imgbg.color = new Color32(10, 10, 10, 0);
    }
}

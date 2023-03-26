using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Author: apostolos SOVOLOS
//Version: 1.0

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] protected bool isOn, isJammed; //jammed = can't be used
    [SerializeField] private GameObject leverOn, leverOff;
    [SerializeField] private Rigidbody doorRb;
    [SerializeField] UnityEvent onLeverOn, onLeverOff;
    [TextArea(2, 10)]
    [SerializeField] protected string jammedText = "Lever is jammed."; //output text if lever is jammed/can't be used

    // Start is called before the first frame update
    void Start()
    {
        leverOn.SetActive(isOn);
        leverOff.SetActive(!isOn);
    }

    //OnInteract is by Interactor (Player), implementation from IInteractable
    public virtual void OnInteract(Interactor interactor)
    {
        if (isJammed)
        {
            interactor.ReceiveInteract(jammedText); //send text to output
        }
        else
        {
            isOn = !isOn; //boolean switch

            leverOn.SetActive(isOn);
            leverOff.SetActive(!isOn);

            //doorRb.isKinematic = !isOn;
            if (isOn)
            {
                onLeverOn.Invoke();
            }
            else onLeverOff.Invoke();

            //string a = isOn ? "on" : "off";
        }
    }

    //Make lever unusable and update lever
    public void Jam()
    {
        isJammed = true;
        isOn = false;
    }

    //Make Lever usable
    public void UnJam()
    {
        isJammed = false;
    }

    public void OnEndInteract()
    {
    }

    public void OnReadyInteract()
    {
    }

    public void OnAbortInteract()
    {
    }
}
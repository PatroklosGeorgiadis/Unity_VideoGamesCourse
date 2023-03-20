using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCwave : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("wave");
           // animator.ResetTrigger("wave");
           // animator.SetBool("test", true);
        }
    }
}

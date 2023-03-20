using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PaladinPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] private Transform[] points;
    int points_idx;
    bool walking = false;
    bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        points_idx = -1;
        walking = false;
        animator.SetBool("Walking", false);
        StartCoroutine(NextPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !waiting && !agent.pathPending)
        {
            StartCoroutine(NextPoint());
        }
    }

    IEnumerator NextPoint()
    {
        walking = false;
        waiting = true;
        animator.SetBool("Walking", walking);

        float randomSeconds = Random.Range(4, 8);
        yield return new WaitForSeconds(randomSeconds);

        points_idx = (points_idx + 1) % points.Length;
        agent.SetDestination(points[points_idx].position);

        walking = true;
        waiting = false;
        animator.SetBool("Walking", walking);

        yield return null;
    }
}

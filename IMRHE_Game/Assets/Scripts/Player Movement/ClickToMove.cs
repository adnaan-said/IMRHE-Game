using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent navMeshAgent;

    private bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }
        }

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }

        animator.SetBool("Walking", walking);
    }
}

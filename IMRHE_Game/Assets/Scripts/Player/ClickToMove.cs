using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent navMeshAgent;

    private Player player;

    private Pause pause;

    private bool walking = false;


    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<Pause>();
        animator = GetComponent<Animator>();    
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (pause.checkPause())
        {
            navMeshAgent.ResetPath();
        }

        if (Input.GetMouseButtonDown(0)&&pause.notPaused())
        {
            if(Physics.Raycast(ray,out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }
        }
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            walking = false;
            navMeshAgent.updateRotation = false;
        }
        else
        {
            walking = true;
            navMeshAgent.updateRotation = true;
        }
        

    }
    public bool getAnimState()
    {
        return walking;
    }


}



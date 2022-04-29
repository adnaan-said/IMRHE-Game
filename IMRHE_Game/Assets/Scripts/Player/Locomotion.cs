using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
[RequireComponent (typeof(Animator))]
public class Locomotion : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMeshAgent;
    ClickToMove click;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<ClickToMove>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //stop automatic update of position so we cna sync with the anim
        //navMeshAgent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldDeltaPosition = navMeshAgent.nextPosition - transform.position;

        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        //low-passes the anim against 1.0
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-5f)//1e-5f => 0.00001 => 1*(10^-5)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove=click.getAnimState();
        animator.SetBool("Walking", shouldMove);
        animator.SetFloat("velx", velocity.x);
        animator.SetFloat("vely", velocity.y);

        //GetComponent<LookAt>().lookAtTargetPosition = navMeshAgent.steeringTarget + transform.forward;
    }
    private void OnAnimatorMove()
    {
        transform.position = navMeshAgent.nextPosition;
    }
}

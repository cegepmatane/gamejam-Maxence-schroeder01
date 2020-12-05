using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class mummy : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    Vector2 movement;
    public Animator animator;
    private bool m_Isflipped = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(player.position);
        movement.x = agent.nextPosition.x;
        movement.y = agent.nextPosition.y;

        if (m_Isflipped == false && movement.x > 0)
        {
            Flip();
        }
        else if (m_Isflipped == true && movement.x < 0)
        {
            Flip();
        }
        animator.SetFloat("Horizontal", agent.nextPosition.x);
        animator.SetFloat("Vertical", agent.nextPosition.y);
        animator.SetFloat("Speed", agent.nextPosition.sqrMagnitude);
    }
    private void Flip()
    {
        m_Isflipped = !m_Isflipped;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

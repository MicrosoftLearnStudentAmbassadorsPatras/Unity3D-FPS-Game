using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	Transform player;
    Camera cam;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Animator animator;

    public int maxHealth;
    public float attackDistance;

    // Use this for initialization
    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHealth <= 0)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("dead", true);
            GetComponent<Collider>().enabled = false;
        }
        else
            navMeshAgent.SetDestination(player.position);



        if (navMeshAgent.remainingDistance <= attackDistance)
        {
            animator.SetBool("attacking", true);
        }
        else
        {
            animator.SetBool("attacking", false);
        }
    }

    public void ReceiveDamage()
    {
        maxHealth--;
    }
}

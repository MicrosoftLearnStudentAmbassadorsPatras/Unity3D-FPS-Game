﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    //public GameObject destination;
	Transform player;
    Camera cam;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Animator animator;
    //public GameObject lazerShot;
    //AudioSource audio;
    //public GameObject laserEmiter;

    //float positionUpdateTime = 0.25f;
    //float positionUpdateTimeElapsed = 0.0f;
    //float shootTime = 0.8f;
    //float shootTimeElapsed = 0.0f;

    public int maxHealth;
    

    public float attackDistance;

    // Use this for initialization
    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
        //audio = GetComponent<AudioSource>();
        //Invoke("Shoot", Random.Range(1f, 5f));


        //Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        /*positionUpdateTimeElapsed += Time.deltaTime;
        shootTimeElapsed += Time.deltaTime;

        if (positionUpdateTimeElapsed >= positionUpdateTime)
        {
            navMeshAgent.SetDestination(player.position);
            positionUpdateTimeElapsed = 0.0f;
        }*/

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

        //Vector3 direction = (player.transform.position - this.transform.position).normalized; //direction towards player

        //this.transform.rotation = Quaternion.LookRotation(direction); //make it a Quaternion and assign it
    }

    /*void Shoot()
	{
		if (navMeshAgent.remainingDistance <= 6f)
		{
			Vector3 laserRotation = new Vector3 (transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

			Instantiate (lazerShot, laserEmiter.transform.position, Quaternion.Euler (laserRotation));
			audio.Play ();
		}
		Invoke("Shoot", Random.Range(1f, 5f));
	}*/

    public void ReceiveDamage()
    {
        maxHealth--;
    }
}

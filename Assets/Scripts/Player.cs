using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField] private float shootDistance = 10;
    private Transform targetedEnemy;
    private bool enemyClicked;
    private bool walking;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent navAgent;
    private float timeBetweenShots = 2f;
    private float nextFire;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 200))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    navAgent.destination = hit.point;
                    navAgent.Resume();
                }
            }
        }

        if (enemyClicked)
        {
            MoveAndShot();
        }

        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }

        //anim.SetBool("IsWalking", walking);
    }

    void MoveAndShot()
	{
	    if (targetedEnemy == null)
	    {
	        return;
	    }

	    navAgent.destination = targetedEnemy.position;

	    if (navAgent.remainingDistance >= shootDistance)
	    {
	        navAgent.Resume();
	        walking = true;
	    }

	    if (navAgent.remainingDistance <= shootDistance)
	    {
	        transform.LookAt(targetedEnemy);

	        if (Time.time > nextFire)
	        {
	            nextFire = Time.time + timeBetweenShots;
	            Fire();
	        }

	        navAgent.Stop();
	        walking = false;
	    }
	}

    void Fire()
    {
        print("FIRE!!!!");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarBehaviour : MonoBehaviour {

    private Transform target;
    private NavMeshAgent agent;
    public bool isFollowing;

    [HideInInspector]
    public bool DL;
    [HideInInspector]
    public bool DR;
    [HideInInspector]
    public bool UL;
    [HideInInspector]
    public bool UR;
    [HideInInspector]
    public bool pFollowing;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        if (pFollowing)
            agent.stoppingDistance = 8;
        agent.destination = target.position;
	}

    public void GetNewTarget(Transform nTarget)
    {
        target = nTarget;
        isFollowing = true;
    }
}

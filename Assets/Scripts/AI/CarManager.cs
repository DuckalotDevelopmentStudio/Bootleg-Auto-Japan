using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

    public GameObject[] cars;
    public Transform[] targets;
    private GameObject pCar;

    private bool DL;
    private bool DR;
    private bool UL;
    private bool UR;
    private int pFollowing;

    // Use this for initialization
    void Start () {
        cars = GameObject.FindGameObjectsWithTag("AI");
        pCar = GameObject.FindGameObjectWithTag("Player");
        pFollowing = 0;
        DL = false;
        DR = false;
        UL = false;
        UR = false;
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < cars.Length; i++)
        {
            if(cars[i].GetComponent<CarBehaviour>().isFollowing == false)
            {
                Debug.Log("number : " + i);
                GiveObjective(i);
            }
        }
	}

    void GiveObjective(int i)
    {
        if(pFollowing <= 0)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(pCar.transform);
            pFollowing++;
            cars[i].GetComponent<CarBehaviour>().pFollowing = true;
        }
        else if(DL && DR && UL && UR)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(pCar.transform);
            pFollowing++;
            cars[i].GetComponent<CarBehaviour>().pFollowing = true;
        }
        else if(DL == false)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(targets[0]);
            DL = true;
            cars[i].GetComponent<CarBehaviour>().DL = true;
        }
        else if (DR == false)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(targets[1]);
            DR = true;
            cars[i].GetComponent<CarBehaviour>().DR = true;
        }
        else if (UL == false)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(targets[2]);
            UL = true;
            cars[i].GetComponent<CarBehaviour>().UL = true;
        }
        else if (UR == false)
        {
            cars[i].GetComponent<CarBehaviour>().GetNewTarget(targets[3]);
            DL = true;
            cars[i].GetComponent<CarBehaviour>().UR = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gunner : MonoBehaviour {

    bool foundCar = false;
    bool foundGunner = false;
    GameObject car;
    GameObject shooter;
	// Use this for initialization
	void Start () {

        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero ;
        if (!foundCar)
        {
            car = GameObject.Find("Car(Clone)");
            if(car != null)
            {
                foundCar = true;

                Debug.Log("Found Car");
            }
        } 
        if(foundCar && !foundGunner)
        {
            for (int i = 0; i < car.transform.childCount; i++)
            {
                if(car.transform.GetChild(i).name == "Gunner")
                {
                    foundGunner = true;
                    shooter = car.transform.GetChild(i).gameObject;
                    //GetComponent<NetworkTransformChild>().target = shooter.transform;
                    Debug.Log("Found Gunner");
                    transform.parent = shooter.transform;
                    car.GetComponent<CarLoaded>().SetupCar();
                    transform.localPosition = Vector3.zero;
                }
            }
        }


        if (foundGunner)
        {

            //transform.position = Vector3.Lerp(transform.position , shooter.transform.position, Time.deltaTime * 29);
            //transform.position = shooter.transform.position;
        }

    }
    
}

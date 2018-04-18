using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarLoaded : NetworkBehaviour {

    public bool loaded = false;
    
    public void SetupCar()
    {

        GameObject.Find("AIManager").GetComponent<CarManager>().Startup();
        Debug.Log("HELLO");
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "Gunner")
            {
                NetworkTransformChild[] ntc = new NetworkTransformChild[GetComponents<NetworkTransformChild>().Length];
                ntc = GetComponents<NetworkTransformChild>();
                for(int j = 0; j < GetComponents<NetworkTransformChild>().Length; j++)
                {
                    ntc[j].enabled = true;
                }
                
            }
        }
        loaded = true;

        
    }
}

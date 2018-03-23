using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarLoaded : NetworkBehaviour {

    public bool loaded = false;
    
    public void SetupCar()
    {
        Debug.Log("HELLO");
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "Gunner")
            {

                gameObject.AddComponent<NetworkTransformChild>().target = transform.GetChild(i).GetChild(0).GetChild(0);
                gameObject.GetComponent<NetworkTransformChild>().interpolateRotation = 10f;
                gameObject.AddComponent<NetworkTransformChild>().target = transform.GetChild(i).GetChild(0);
                gameObject.AddComponent<NetworkTransformChild>().target = transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0);
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

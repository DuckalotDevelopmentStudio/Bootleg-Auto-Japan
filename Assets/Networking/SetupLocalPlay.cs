using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlay : NetworkBehaviour {

    private void Start()
    {
        if(isLocalPlayer)
        {
            if(GetComponent<Gunner>())
            {

                transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
                GetComponent<CameraController>().enabled = true;
                GetComponent<CameraController>().Setup();
                Camera.main.transform.parent = transform.GetChild(0);
                Camera.main.transform.position = Vector3.zero;
                transform.GetChild(0).GetComponentInChildren<Scope>().enabled = true ;
                GetComponentInChildren<GunController>().enabled = true;

            } else
            {
                GetComponent<Move>().enabled = true;
                Camera.main.transform.parent = transform;
                Camera.main.transform.position = Vector3.zero;
                Camera.main.gameObject.AddComponent<CameraFollow>().follow = gameObject;
            }
        }

    }
}

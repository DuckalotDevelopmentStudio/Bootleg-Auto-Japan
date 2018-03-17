using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlay : NetworkBehaviour {

    private void Start()
    {
        if(isLocalPlayer)
        {
            Camera.main.transform.parent = transform;
            Camera.main.transform.position = Vector3.zero;
            GetComponent<Move>().enabled = true;
        }

    }
}

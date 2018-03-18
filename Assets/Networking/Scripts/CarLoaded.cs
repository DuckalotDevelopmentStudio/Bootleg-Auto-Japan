using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarLoaded : MonoBehaviour {

    public bool loaded = false;

    public void Setup()
    {
        loaded = true;
        gameObject.AddComponent<NetworkTransformChild>().enabled = true;
        gameObject.GetComponent<NetworkTransformChild>().target = GameObject.Find("Person(Clone)").transform;
    }
}

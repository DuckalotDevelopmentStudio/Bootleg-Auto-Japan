using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject follow;

	void Update () {
        transform.position = follow.transform.position;
	}
}

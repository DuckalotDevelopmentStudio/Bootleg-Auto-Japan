using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

    [Header("Customizable Attributes")]
    public Camera defCam;
    public Camera scopeCam;
    public static Vector3 currentLookAt;
    public Camera[] scopeCams; //Support for switching guns

    private void Start()
    {
        scopeCam.enabled = false;
    }

    public void ScopeIn() //Enables camera on Scope
    {
        scopeCams[0/*To be changed from hard code*/].enabled = true;
        defCam.enabled = false;
    }

    public void ScopeOut() //Disables camera on scope
    {
        scopeCams[0].enabled = false;
        defCam.enabled = true;
    }

}

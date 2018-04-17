using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        scopeCam.enabled = true;
        defCam.enabled = false;
    }

    public void ScopeOut() //Disables camera on scope
    {
        scopeCam.enabled = false;
        defCam.enabled = true;
    }

}

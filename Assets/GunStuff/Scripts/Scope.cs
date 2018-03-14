using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour {

    [Header("Customizable Attributes")]
    public Camera defCam;
    public Camera scopeCam;
    public Image hipScope;
    public Image scope;
    public static Vector3 currentLookAt;
    public Camera[] scopeCams; //Support for switching guns

    private void Start()
    {
        scopeCam.enabled = false;
        scope.enabled = false;
    }

    public void ScopeIn() //Enables camera on Scope
    {
        scopeCams[0/*To be changed from hard code*/].enabled = true;
        defCam.enabled = false;
        hipScope.enabled = false;
        scope.enabled = true;
    }

    public void ScopeOut() //Disables camera on scope
    {
        scopeCams[0].enabled = false;
        defCam.enabled = true;
        hipScope.enabled = true;
        scope.enabled = false;
    }

}

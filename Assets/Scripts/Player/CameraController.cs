using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Customizable Atrributes")]
    [Range(0f,25f)]
    public float mouseSensX = 5f;
    [Range(0f, 25f)]
    public float mouseSensY = 5f;
    [Range(0f, 25f)]
    public float scopedSens = 5f;

    //Local Variables
    GunController gunController;
    GameObject player;
    GameObject mouse;
    public Camera cam;
    //Global Inspectors
    [HideInInspector]
    public float rotationX = 0;
    [HideInInspector]
    public float rotationY = 0;
    bool gunControler;

    private void Start()
    {
        player = GameObject.Find("Person");
        gunController = GameObject.Find("Gun").GetComponent<GunController>();
        if (gunController == null)
        {
            gunControler = false;
        } else
        {
            gunControler = true;
        }
    }
    // Update is called once per frame
    void Update ()
    {
                rotationX += Input.GetAxis("Mouse X") * mouseSensX;
                rotationY -= Input.GetAxis("Mouse Y") * mouseSensY;
            
        if(gunControler)
        {
            if (gunController.scoped)
            {
                rotationX += Input.GetAxis("Mouse X") * scopedSens;
                rotationY -= Input.GetAxis("Mouse Y") * scopedSens;
            }
            
        }
        rotationY = Mathf.Clamp(rotationY, -60, 60);
        cam.gameObject.transform.localRotation = Quaternion.Euler(cam.gameObject.transform.localRotation.x,rotationX, transform.localRotation.z);
        gameObject.transform.localRotation = Quaternion.Euler(rotationY, transform.localRotation.y, transform.localRotation.z);
    }
}

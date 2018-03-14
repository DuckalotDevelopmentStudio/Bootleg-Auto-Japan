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
    Camera cam;
    //Global Inspectors
    [HideInInspector]
    public float rotationX = 0;
    [HideInInspector]
    public float rotationY = 0;

    private void Start()
    {
        player = GameObject.Find("Person");
        mouse = GameObject.Find("Mouse");
        cam = GetComponent<Camera>();
        gunController = GameObject.Find("Gun").GetComponent<GunController>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (gunController.scoped == false)
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensX;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensY;
        } else
        {
            rotationX += Input.GetAxis("Mouse X") * scopedSens;
            rotationY -= Input.GetAxis("Mouse Y") * scopedSens;
        }
        rotationY = Mathf.Clamp(rotationY, -60, 60);
        transform.localRotation = Quaternion.Euler(rotationY,rotationX, transform.localRotation.z);
    }
}

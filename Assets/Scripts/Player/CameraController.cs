using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour {

    [Header("Customizable Atrributes")]
    [Range(0f,25f)]
    public float mouseSensX = 5f;
    [Range(0f, 25f)]
    public float mouseSensY = 5f;
    [Range(0f, 25f)]
    public float scopedSens = 5f;
    [Space]
    //Local Variables
    bool gunControllerOnObject;
    GunController gunController;
    public GameObject player;
    GameObject mouse;
    public Camera cam;
    //Global Inspectors
    [HideInInspector]
    public float rotationX = 0;
    [HideInInspector]
    public float rotationY = 0;

    public void Setup()
    {
        if(GetComponent<GunController>())
        {
            gunController = GetComponent<GunController>();
            gunControllerOnObject = true;

        } else
        {
            gunControllerOnObject = false;
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
            rotationX += Input.GetAxis("Mouse X") * mouseSensX;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensY;
        if(gunControllerOnObject && gunController.scoped)
        {
            rotationX += Input.GetAxis("Mouse X") * scopedSens;
            rotationY -= Input.GetAxis("Mouse Y") * scopedSens;
        }
        rotationY = Mathf.Clamp(rotationY, -60, 60);
        cam.transform.localRotation = Quaternion.Euler(rotationY,0, 0);
        player.transform.localRotation = Quaternion.Euler(0, rotationX, 0);
    }
 
}

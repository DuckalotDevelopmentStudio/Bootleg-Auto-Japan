using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour {

    [Header("Customizable Atrributes")]
    [Range(0f,25f)]
    public float mouseSensX = 5f;
    [Range(0f, 25f)]
    public float mouseSensY = 5f;
    [Range(0f, 25f)]
    public float scopedSens = 5f;
    [Space]
    //Local Variables
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
        gunController = GetComponent<GunController>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (!gunController.scoped)
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensX;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensY;
        } else
        {
            rotationX += Input.GetAxis("Mouse X") * scopedSens;
            rotationY -= Input.GetAxis("Mouse Y") * scopedSens;
        }
        rotationY = Mathf.Clamp(rotationY, -60, 60);
        cam.transform.localRotation = Quaternion.Euler(rotationY,transform.localRotation.y, transform.localRotation.z);
        player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.x, rotationX, player.transform.localRotation.z);
    }
}

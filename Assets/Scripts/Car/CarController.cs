using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Car : System.Object
{
    public WheelCollider leftWheel;
    public GameObject leftWheelMesh;
    public WheelCollider rightWheel;
    public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
    public bool reverseTurn;
}

public class CarController : MonoBehaviour
{

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<Car> carInfo;

    private Rigidbody rb;
    public bool useCustomCOM = false;
    //Center of mass
    public Transform com;

    public void Start()
    {

        rb = GetComponent<Rigidbody>();
        if (useCustomCOM)
        {
            rb.centerOfMass = new Vector3(com.transform.position.x, com.transform.position.y, com.transform.position.z);
        }
        
    }

    public void VisualizeWheel(Car wheelPair)
    {
        Quaternion rot;
        Vector3 pos;
        wheelPair.leftWheel.GetWorldPose(out pos, out rot);
        wheelPair.leftWheelMesh.transform.position = pos;
        wheelPair.leftWheelMesh.transform.rotation = rot;
        wheelPair.rightWheel.GetWorldPose(out pos, out rot);
        wheelPair.rightWheelMesh.transform.position = pos;
        wheelPair.rightWheelMesh.transform.rotation = rot;
    }

    public void Update()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * -Input.GetAxis("Horizontal");
        float breakTorque = Mathf.Abs(Input.GetAxis("Jump"));
        if (breakTorque > 0.001)
        {
            breakTorque = maxMotorTorque;
            motor = 0;
        }
        else
        {
            breakTorque = 0;
        }

        foreach (Car info in carInfo)
        {
            if (info.steering == true)
            {
                info.leftWheel.steerAngle = info.rightWheel.steerAngle = ((info.reverseTurn) ? -1 : 1) * steering;
            }

            if (info.motor == true)
            {
                info.leftWheel.motorTorque = motor;
                info.rightWheel.motorTorque = motor;
            }

            info.leftWheel.brakeTorque = breakTorque;
            info.rightWheel.brakeTorque = breakTorque;

            VisualizeWheel(info);
        }

    }


}
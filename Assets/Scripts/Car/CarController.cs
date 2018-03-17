

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WheelPosition { Front, Rear };

[System.Serializable]
public class Wheel : System.Object
{
    public WheelCollider collider;
    public GameObject mesh;
    public WheelPosition wheelPos;
}

public class CarController : MonoBehaviour
{

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float AntiRoll;

    public Wheel[] wheels;

    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void VisualizeWheel(Wheel wheel)
    {
        Quaternion rotation;
        Vector3 position;
        wheel.collider.GetWorldPose(out position, out rotation);
        wheel.mesh.transform.position = position;
        wheel.mesh.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
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

        for(int i = 0; i < wheels.Length; i+=2){
            DoRollBar(wheels[i].collider, wheels[i+1].collider);
        }

        foreach (Wheel wheel in wheels)
        {
            if(wheel.wheelPos == WheelPosition.Front){
                wheel.collider.steerAngle = steering;
            }

            wheel.collider.motorTorque = motor;

            wheel.collider.brakeTorque = breakTorque;


            VisualizeWheel(wheel);
        }

    }

    void DoRollBar(WheelCollider WheelL, WheelCollider WheelR) {
		WheelHit hit;
		float travelL = 1.0f;
		float travelR = 1.0f;
		
		bool groundedL = WheelL.GetGroundHit(out hit);
		if (groundedL)
			travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;
		
		bool groundedR = WheelR.GetGroundHit(out hit);
		if (groundedR)
			travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;
		
		float antiRollForce = (travelL - travelR) * AntiRoll;
		
		if (groundedL)
			rb.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
			                             WheelL.transform.position); 
		if (groundedR)
			rb.AddForceAtPosition(WheelR.transform.up * antiRollForce,
			                             WheelR.transform.position); 
	}


}
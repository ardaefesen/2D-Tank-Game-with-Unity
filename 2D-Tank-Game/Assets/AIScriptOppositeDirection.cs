using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScriptOppositeDirection : MonoBehaviour
{

    public Rigidbody rb;
    public Transform transform;
    public float speed = 19;


    Vector3 forward = new Vector3(0, 0, 1);


    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;


    private void Update()
    {
        transform.Translate(forward * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        collider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}

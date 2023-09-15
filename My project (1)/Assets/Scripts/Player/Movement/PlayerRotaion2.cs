using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerRotaion2 : MonoBehaviour
{
    public float MinYaw = -360;
    public float MaxYaw = 360;
    public float MinPitch = -60;
    public float MaxPitch = 60;
    public float LookSensitivity = 1;

    public float MoveSpeed = 10;
    public float SprintSpeed = 30;
    private float currMoveSpeed = 0;

    public Transform cameraPoint;

    protected CharacterController movementController;
    
    protected float yaw;
    protected float pitch;

    protected Vector3 velocity;
    public Vector3 InputDirection;


    protected virtual void Start()
    {
        movementController = GetComponent<CharacterController>();   //  Character Controller
    }

    protected virtual void Update()
    {
        Move();
    }

    
    private void Move()
    {
        Vector3 direction = Vector3.zero;
        direction += transform.forward * Input.GetAxisRaw("Vertical");
        direction += transform.right * Input.GetAxisRaw("Horizontal");

        direction.Normalize();
        InputDirection = direction;
        if (movementController.isGrounded)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity += -transform.up * (9.81f * 10) * Time.deltaTime; // Gravity
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {  // Player can sprint by holding "Left Shit" keyboard button
            currMoveSpeed = SprintSpeed;
            InputDirection *= 2;
        }
        else
        {
            currMoveSpeed = MoveSpeed;
        }

        direction += velocity * Time.deltaTime;
        movementController.Move(direction * Time.deltaTime * currMoveSpeed);

        // Camera Look
        yaw += Input.GetAxisRaw("Mouse X") * LookSensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;

        yaw = ClampAngle(yaw, MinYaw, MaxYaw);
        pitch = ClampAngle(pitch, MinPitch, MaxPitch);

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        cameraPoint.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    protected float ClampAngle(float angle)
    {
        return ClampAngle(angle, 0, 360);
    }

    protected float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

}
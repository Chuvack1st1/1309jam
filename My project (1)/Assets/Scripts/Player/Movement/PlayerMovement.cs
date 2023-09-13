using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    private Vector2 velocity;

    public Vector2 Velocity { get => velocity; private set => velocity = value; }

    private void FixedUpdate()
    {
        Velocity = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.position += new Vector3(Velocity.x, 0, Velocity.y) * MovementSpeed * Time.deltaTime;
    }
}

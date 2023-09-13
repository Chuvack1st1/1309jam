using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float Sensivity;

    private Vector2 mouseInput;

    [SerializeField] private Transform player;

    public Vector2 MouseInput { get => mouseInput; private set => mouseInput = value; }

    private void FixedUpdate()
    {
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        player.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, MouseInput.x, 0) * Sensivity);
    }
}

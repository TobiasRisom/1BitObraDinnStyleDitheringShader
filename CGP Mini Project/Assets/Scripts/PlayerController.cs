using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // This is a quick character controller, thrown together to make walking around the objects possible

    public Transform body;
    float mouseSpeed = 10f;

    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        // Locks cursor so the player can turn as much as they want
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the body depending on the mouse's x-position
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        body.Rotate(Vector3.up * mouseX);

        // Move the player with the direction keys (Arrow Keys or WASD)
        float r = Input.GetAxis("Horizontal");
        float f = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * r + transform.forward * f;
        controller.Move(movement * 10 * Time.deltaTime);
    }
}

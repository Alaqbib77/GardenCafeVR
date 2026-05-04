using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public float verticalSpeed = 5f;

    float yaw;

    void Update()
    {
        Vector2 moveInput = Vector2.zero;
        float vertical = 0f;

        // WASD movement
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
            if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
            if (Keyboard.current.dKey.isPressed) moveInput.x += 1;

            // UP / DOWN
            if (Keyboard.current.spaceKey.isPressed) vertical += 1;
            if (Keyboard.current.leftCtrlKey.isPressed) vertical -= 1;
        }

        // 🖱️ Trackpad scroll = turn left/right
        if (Mouse.current != null)
        {
            float scrollX = Mouse.current.scroll.ReadValue().x;
            yaw += scrollX * turnSpeed * Time.deltaTime;
        }

        // Apply rotation (yaw only)
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Horizontal movement (relative to rotation)
        Vector3 horizontalMove =
            transform.forward * moveInput.y +
            transform.right * moveInput.x;

        // Add vertical movement (world up/down)
        Vector3 finalMove = horizontalMove + Vector3.up * vertical;

        transform.position += finalMove * moveSpeed * Time.deltaTime;
    }
}
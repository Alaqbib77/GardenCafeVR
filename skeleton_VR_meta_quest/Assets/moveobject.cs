using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleGrab : MonoBehaviour
{
    bool held = false;
    Rigidbody rb;

    public Transform playerCamera;
    public float grabDistance = 5f;
    public float grabRadius = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerCamera == null)
        {
            playerCamera = GameObject.Find("CenterEyeAnchor").transform;
        }
    }

    void Update()
    {
        if (Mouse.current == null) return;

        // PICK UP
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, grabRadius, out hit, grabDistance))
            {
                // grab ANY object with SimpleGrab on it
                SimpleGrab grab = hit.transform.GetComponent<SimpleGrab>();

                if (grab != null && grab == this)
                {
                    held = true;
                    rb.isKinematic = true;

                    transform.SetParent(playerCamera);
                    transform.localPosition = Vector3.forward * 1.5f;
                }
            }
        }

        // DROP
        if (Mouse.current.leftButton.wasReleasedThisFrame && held)
        {
            held = false;

            transform.SetParent(null);
            rb.isKinematic = false;
        }
    }
}
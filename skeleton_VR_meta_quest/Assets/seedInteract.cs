using UnityEngine;
using UnityEngine.InputSystem;

public class SeedInteract : MonoBehaviour
{
    public Transform centerEyeAnchor;
    public float interactDistance = 3f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (centerEyeAnchor == null) return;

            Ray ray = new Ray(centerEyeAnchor.position, centerEyeAnchor.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.transform.CompareTag("SeedSack"))
                {
                    SeedSack sack = hit.transform.GetComponent<SeedSack>();
                    if (sack != null)
                    {
                        sack.GiveSeed();
                    }
                }
            }
        }
    }
}
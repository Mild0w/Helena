using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float pushForce = 10f;

    private void OnMouseDown()
    {
        ApplyPushForce();
    }

    private void ApplyPushForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 pushDirection = Camera.main.transform.forward;
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}


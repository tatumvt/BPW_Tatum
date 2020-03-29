using UnityEngine;

public class TriggerJump : MonoBehaviour
{

    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponentInParent<Rigidbody>();
        if (otherRigidbody != null)
        {
            otherRigidbody.AddForce(Vector3.up * force, ForceMode.Force);
        }
    }
}

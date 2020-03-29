using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform body;
    public float sensX = 10;
    public float sensY = 5;
    private float angleX = 0;
    private float angleY = 0;


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        angleX += mouseX * sensX;
        angleY += mouseY * sensY;

        angleY = Mathf.Clamp(angleY, -85f, 85f);

        transform.localRotation = Quaternion.Euler(-angleY, 0, 0);
        body.transform.localRotation = Quaternion.Euler(0, angleX, 0);

    }
}

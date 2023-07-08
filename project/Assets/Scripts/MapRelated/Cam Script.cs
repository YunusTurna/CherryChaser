using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Fare hareketini al
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Kamerayı yatay eksende döndür
        transform.Rotate(0f, mouseX * rotationSpeed, 0f);

        // Kamerayı dikey eksende döndür ve sınırla
        float rotationX = transform.localEulerAngles.x - mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0f);
    }
}
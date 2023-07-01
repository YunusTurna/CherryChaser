using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public Transform target;            // Kameranýn etrafýnda dönülecek hedef nesne (karakter)
    public float rotationSpeed = 3f;    // Kamera dönüþ hýzý
    public float verticalSpeed = 2f;    // Dikey dönüþ hýzý

    public float minVerticalAngle = -60f;  // Minimum dikey açý
    public float maxVerticalAngle = 60f;   // Maksimum dikey açý

    private float yaw = 0f;             // Yatay dönüþ açýsý
    private float pitch = 0f;           // Dikey dönüþ açýsý
    Vector3 offset;

    void Start()
    {
        // Kamera ile hedef arasýndaki mesafeyi hesapla
        Vector3 offset = transform.position - target.position;

        // Yatay ve dikey açýlarý hesapla
        yaw = Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg;
        pitch = Mathf.Asin(offset.y / offset.magnitude) * Mathf.Rad2Deg;

        // Fare imleci gizleniyor ve sýnýrlarý belirleniyor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Fare giriþini al
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        // Yatay dönüþ açýsýný güncelle
        yaw += mouseX;

        // Dikey dönüþ açýsýný güncelle ve sýnýrla
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);

        // Yeni rotasyonu hesapla
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Kameranýn rotasyonunu güncelle ve pozisyonu hedefin etrafýnda ayarla
        transform.rotation = rotation;
        transform.position = target.position - rotation * Vector3.forward * offset.magnitude;

        // Hedefe bakmasýný saðla
        transform.LookAt(target);
    }
}

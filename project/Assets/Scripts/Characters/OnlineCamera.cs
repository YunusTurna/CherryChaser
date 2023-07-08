using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineCamera : MonoBehaviourPunCallbacks
{
    public Transform target;            // Kameran�n etraf�nda d�n�lecek hedef nesne (karakter)
    public float rotationSpeed = 3f;    // Kamera d�n�� h�z�
    public float verticalSpeed = 2f;    // Dikey d�n�� h�z�

    public float minVerticalAngle = -60f;  // Minimum dikey a��
    public float maxVerticalAngle = 60f;   // Maksimum dikey a��

    private float yaw = 0f;             // Yatay d�n�� a��s�
    private float pitch = 0f;           // Dikey d�n�� a��s�
    Vector3 offset;

    void Start()
    {
        if (!photonView.IsMine) return;
        // Kamera ile hedef aras�ndaki mesafeyi hesapla
        Vector3 offset = transform.position - target.position;

        // Yatay ve dikey a��lar� hesapla
        yaw = Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg;
        pitch = Mathf.Asin(offset.y / offset.magnitude) * Mathf.Rad2Deg;

        // Fare imleci gizleniyor ve s�n�rlar� belirleniyor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!photonView.IsMine) return;
        // Fare giri�ini al
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        // Yatay d�n�� a��s�n� g�ncelle
        yaw += mouseX;

        // Dikey d�n�� a��s�n� g�ncelle ve s�n�rla
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);

        // Yeni rotasyonu hesapla
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Kameran�n rotasyonunu g�ncelle ve pozisyonu hedefin etraf�nda ayarla
        transform.rotation = rotation;
        transform.position = target.position - rotation * Vector3.forward * offset.magnitude;

        // Hedefe bakmas�n� sa�la
        transform.LookAt(target);
    }
}

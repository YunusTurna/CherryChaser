using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollBodies;
    private Animator animator;

    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        SetRagdollState(false); // Ragdoll'ü başlangıçta devre dışı bırak

        // Ana karakteri hareket ettirme
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Ragdoll devre dışı olduğunda karakter kontrolüne izin ver
        if (!animator.enabled)
        {
            float moveInput = Input.GetAxis("Vertical");
            float rotateInput = Input.GetAxis("Horizontal");

            // Karakteri hareket ettirme
            transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);
        }

        // "R" tuşuna basıldığında Ragdoll'ü etkinleştir veya devre dışı bırak
        if (Input.GetKeyDown(KeyCode.R))
        {
            bool ragdollEnabled = !animator.enabled;
            SetRagdollState(ragdollEnabled);
        }
    }

    private void SetRagdollState(bool isEnabled)
    {
        foreach (Rigidbody body in ragdollBodies)
        {
            body.isKinematic = !isEnabled;
            body.detectCollisions = isEnabled;
        }

        animator.enabled = !isEnabled;
    }
}









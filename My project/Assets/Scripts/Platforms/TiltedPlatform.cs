using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltedPlatform : MonoBehaviour
{
    
    public float rotationAngle = 45f;
    public float rotationSpeed = 1f;

    private int rotationDirection = 1;
    private float currentRotation = 0f;

    void Update()
    {
        // Hesaplanacak dönme açısını belirleyin
        float targetRotation = rotationDirection * rotationAngle;

        // Hedefe ulaşmadıysak dönme işlemini gerçekleştirin
        if (Mathf.Abs(currentRotation - targetRotation) > 0.1f)
        {
            // Dönme miktarını hesaplayın ve dönme işlemini gerçekleştirin
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationDirection * rotationAmount* Time.deltaTime);
            currentRotation += rotationDirection * rotationAmount;
        }
        else
        {
            // Hedefe ulaşıldığında dönme yönünü değiştirin
            rotationDirection *= -1;
        }
    }
}

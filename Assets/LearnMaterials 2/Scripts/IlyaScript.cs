using System.Collections;
using UnityEngine;

public class IlyaScript : SampleScript
{
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private Vector3 rotationAngle;

    [ContextMenu("Use")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine(rotationSpeed, rotationAngle));
    }

    private IEnumerator RotateCoroutine(float rotationSpeed, Vector3 rotationAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(rotationAngle.x, rotationAngle.y, rotationAngle.z);
        float rotationTime = Mathf.Abs(rotationAngle.magnitude) / rotationSpeed;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * targetRotation;

        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        { 
            float t = elapsedTime / rotationTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = endRotation;
    }
}
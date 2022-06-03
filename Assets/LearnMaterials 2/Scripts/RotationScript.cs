using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : SampleScript
{
    [Range(0, 100)]
    public float speed = 0;
    [SerializeField]
    private Vector3 targetRotE;
    private Quaternion startRot;
    private Quaternion targetRot;
    private bool rotationKey;
    private float currentDegree;
    private float totalDegree;

    private void Start()
    {
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(targetRotE);
        totalDegree = Quaternion.Angle(startRot, targetRot);
    }

    private void Update()
    {
        if (rotationKey)
        {
            currentDegree += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(startRot, targetRot, currentDegree/totalDegree);

            if (currentDegree >= totalDegree)
            {
                rotationKey = false;
            }
             //Around(transform.position, transform.up, Time.deltaTime * speed);
        }
    }

    [ContextMenu("Начать")]
    public override void Use()
    {
        rotationKey = true;
    }
}

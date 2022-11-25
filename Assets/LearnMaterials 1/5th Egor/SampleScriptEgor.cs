using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptEgor : AbstractSampleScript
{
    [Min(0)]
    public float rotationSpeed;
    private float t;
    public float endX;
    public float endY;
    public float endZ;
    private Quaternion startRotation;
    private Quaternion endRotation;

    public void Start()
    {
        startRotation = transform.rotation;
    }

    [ContextMenu("Активировать")]
    public override void Use()
    {
        StartCoroutine(Call());
    }

    public IEnumerator Call()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(new Vector3(endX, endY, endZ));
        t = 0;
        while (transform.rotation != endRotation)
        {
            if (t < 1)
            {
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                t += Time.deltaTime * rotationSpeed / 100;
            }
            else
            {
                transform.rotation = endRotation;
            }

            yield return null;
        }
    }
}
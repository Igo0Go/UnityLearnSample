using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : AbstractSampleScript
{
    [Range(0, 100)]
    public float speed = 1.0f;

    public Vector3 mTargetPosition;

    private bool isUsed = false;

    public override void Use()
    {
        isUsed= true;
    }
    private void Update()
    {
        if(isUsed == true) 
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, mTargetPosition, step);
            if(transform.position == mTargetPosition)
            {
                isUsed = false;
            }
        }
    }
}

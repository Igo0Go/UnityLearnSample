using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : SampleScript
{
    [SerializeField]
    private Vector3 target;
    private bool moveKey;

    private void Update()
    {
        
        if (moveKey)
        {
            Vector3 direction = target - transform.position;

            if (direction.magnitude > 0.3f)
            {
                transform.forward = direction;
                transform.position += direction.normalized * Time.deltaTime;
            }
        }
        
    }

    [ContextMenu("Начать движение")]
    public override void Use()
    {
        moveKey = true;
    }
}


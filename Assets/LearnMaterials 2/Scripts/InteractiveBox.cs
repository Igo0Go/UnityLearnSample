using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    public InteractiveBox next;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (next != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, next.transform.position - transform.position, out hit))
            {
                ObstacleItem obstacle = hit.transform.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime);
                }
            }
        }
    }

    public void AddNext(InteractiveBox box)
    {
        next = box;
        DrawLineToNextBox();
    }

    private void DrawLineToNextBox()
    {
        if (next != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, next.transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}

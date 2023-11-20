using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab;
    private InteractiveBox savedBox;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    Vector3 position = hit.point + hit.normal * (prefab.transform.localScale.x / 2);
                    GameObject newBox = Instantiate(prefab, position, Quaternion.identity);
                }
                else if (hit.collider.CompareTag("InteractiveBox"))
                {
                    InteractiveBox clickedBox = hit.collider.GetComponent<InteractiveBox>();

                    if (savedBox == null)
                    {
                        savedBox = clickedBox;
                    }
                    else
                    {
                        savedBox.AddNext(clickedBox);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractiveBox"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveRayCast : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    InteractiveBox thisBox;

    private IEnumerator onClickCustom()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(obj, raycastHit.point + raycastHit.normal / 2, new Quaternion());
                    }
                    if (raycastHit.transform.TryGetComponent<InteractiveBox>(out InteractiveBox boxItem))
                    {
                        if (thisBox == null)
                        {
                            thisBox = boxItem;
                        }
                        else
                        {
                            thisBox.gameObject.GetComponent<InteractiveBox>().AddNext(boxItem);
                            thisBox = null;
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(obj2, raycastHit.point + raycastHit.normal / 2, new Quaternion());
                    }
                    if (raycastHit.transform.TryGetComponent<InteractiveBox>(out InteractiveBox boxItem))
                    {
                        if (thisBox == null)
                        {
                            thisBox = boxItem;
                        }
                        else
                        {
                            thisBox.gameObject.GetComponent<InteractiveBox>().AddNext(boxItem);
                            thisBox = null;
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.TryGetComponent<InteractiveBox>(out InteractiveBox boxItem))
                    {
                        Destroy(raycastHit.transform.gameObject);
                    }
                }
            }
        }
        yield return null;
    }

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(onClickCustom());

    }
}

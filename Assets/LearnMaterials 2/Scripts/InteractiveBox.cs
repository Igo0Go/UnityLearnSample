using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    public InteractiveBox next;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }
}

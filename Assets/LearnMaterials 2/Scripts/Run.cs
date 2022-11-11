using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    [ContextMenu("Активировать модули")]
    public void Use()
    {

        var objects = FindObjectsOfType<SampleScript>();
        foreach (var script in objects)
        {
            script.Use();
        }
    }
}

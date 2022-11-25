using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptCall : MonoBehaviour
{

    [ContextMenu("Активировать")]
    public void Use()
    {
        var objs = FindObjectsOfType<AbstractSampleScript>();
        foreach (var script in objs)
        {
            script.Use();
        }
    }

}

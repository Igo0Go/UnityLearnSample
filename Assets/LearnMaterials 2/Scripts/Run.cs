using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Use();
        }
    }

    [ContextMenu("������������ ������")]
    public void Use()
    {

        var objects = FindObjectsOfType<SampleScript>();
        foreach (var script in objects)
        {
            script.Use();
        }
    }
}

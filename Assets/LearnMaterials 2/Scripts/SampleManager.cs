using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> target;

    [ContextMenu("Start")]
    void Use()
    {
        foreach (SampleScript obj in target)
        {
            obj.Use();
        }
    }
}


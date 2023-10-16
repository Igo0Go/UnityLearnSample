using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScripts : MonoBehaviour
{
    private List<SampleScript> sampleScripts;

    private void Awake()
    {
        sampleScripts = new List<SampleScript>();
    }
    
    private void AddSampleScript(SampleScript script)
    {
        sampleScripts.Add(script);
    }

    public void UseAll()
    {
        foreach (var script in sampleScripts)
        {
            script.Use();
        }
    }
}

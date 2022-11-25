using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptTemer : SampleScript
{
    public Transform target;

    [ContextMenu("Активировать")]
    public override void Use()
    {
        StartCoroutine(Call());
    }

    public IEnumerator Call()
    {
        Debug.Log(target.childCount);
        int i = 0;
        GameObject[] allChildren = new GameObject[target.childCount];

        foreach (Transform child in target)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach (GameObject child in allChildren)
        {
            Destroy(child.gameObject);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptPodoynikow : SampleScript
{
    public GameObject prefab;

    [Min(0)]
    public int quantity = 3;

    public float step;

    [ContextMenu("Активировать")]
    public override void Use()
    {
        StartCoroutine(Call());
    }

    public IEnumerator Call()
    {
        while (quantity > 0)
        {
            Instantiate(prefab, prefab.transform.position + Vector3.right * step * quantity, prefab.transform.rotation);
            quantity -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}

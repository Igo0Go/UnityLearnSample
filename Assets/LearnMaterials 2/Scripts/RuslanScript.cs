using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RuslanScript : SampleScript
{
    public float speed = 1f;
    public Vector3 target = new Vector3(3f, 0f, 0f);

    private Vector3 startPosition;

    public void Awake()
    {
        startPosition = transform.position;
    }

    [ContextMenu("option")]
    public override void Use()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        float distanceCovered = 0;
        while (true)
        {
            distanceCovered += Time.deltaTime * speed;
            float journeyLength = Vector3.Distance(startPosition, target);

            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);

            yield return null;

            if (fractionOfJourney == 1)
                break;
        }
    }

}

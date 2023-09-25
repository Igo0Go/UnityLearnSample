using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingModule : MonoBehaviour
{
    [Header("Moving������")]

    [SerializeField]
    private float x;

    [SerializeField]
    private float y;

    [SerializeField]
    private float z;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }
    [ContextMenu("�������� - �����")]
    public void ActivateModule()
    {
        StartCoroutine(MoveThisShit());
    }
    private IEnumerator MoveThisShit()
    {
        transform.Translate(x, y, z);
        yield return null;
    }
}

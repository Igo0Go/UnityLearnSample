using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : SampleScript
{

    [Min(0)]
    public int speed = 1;
    public Vector3 _endPosVec = new(4, 1, -6);
    //private Vector3 _startPos;
    private float _startPos;
    private float _endPos;
    public Transform target;
    void Start()
    {
        _startPos = transform.position.z;
        _endPos = target.position.z;
    }


    [ContextMenu("Активировать модуль")]
    public override void Use()
    {
        StartCoroutine(Call());
    }

    private IEnumerator Call()
    {
        //transform.position = Vector3.Lerp(_startPos, _endPos, Time.time);
        //yield return null;

        while (transform.position != _endPos)
        {
            var objTransform = gameObject.transform;
            var direction = _endPos - objTransform.position;
            objTransform.position += direction.normalized * Time.deltaTime * speed;
            yield return null;
        }

        //float _z = Mathf.SmoothStep(_startPos, _endPos, Time.time /(1/speed));
        //Debug.Log(_z);
        //transform.position = _endPosVec;
        //yield return null;
    }
}

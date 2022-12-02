using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private LayerMask obstacleLayerMask;
    [SerializeField]
    InteractiveBox next;
    [SerializeField]
    [ContextMenu("Запуск ракет")]

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (next != null)
        {
            if (Physics.Linecast(transform.position, next.transform.position, out RaycastHit hitbox, obstacleLayerMask))
            {
                Debug.Log("Kill");
                if (hitbox.transform.TryGetComponent<ObstacleItem>(out ObstacleItem obstacleItem))
                {
                    obstacleItem.GetDamage();
                }
            }

        }

    }

    private void OnDrawGizmos()
    {
        if (next != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, next.transform.position);
        }

    }
}

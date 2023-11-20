using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField] private float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    private Renderer obstacleRenderer;
    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        UpdateObstacleColor();
    }
    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue);
        UpdateObstacleColor();


        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }
    }

    private void UpdateObstacleColor()
    {
        Color lerpedColor = Color.Lerp(Color.red, Color.white, currentValue);
        obstacleRenderer.material.color = lerpedColor;
    }
}

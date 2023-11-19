using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField] private float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    private Renderer obstacleRenderer;
    private bool isDestroyed = false;
    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        UpdateObstacleColor();
    }

    void Update()
    {
       if (currentValue <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        } 
    }

    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue);
        UpdateObstacleColor();
    }

    private void UpdateObstacleColor()
    {
        Color lerpedColor = Color.Lerp(Color.red, Color.white, currentValue);
        obstacleRenderer.material.color = lerpedColor;
    }
}

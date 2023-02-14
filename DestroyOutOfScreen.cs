using UnityEngine;
using System.Collections;

public class DestroyOutOfScreen : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 maxWidth;
    public Vector2 maxHeight;


    void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < maxWidth.x || screenPosition.x > maxWidth.y || screenPosition.y < maxHeight.x || screenPosition.y > maxHeight.y)
            Destroy(gameObject);
    }
}
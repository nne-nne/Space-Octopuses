using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float animationSpeed;
    public float movementRange;
    public float baseSpeed, quickerMultiplier;
    private float t = 0;

    void Start()
    {
        
    }

    void Update()
    {
        t += Time.deltaTime;
        transform.Rotate(0f, Mathf.Abs(Mathf.Sin(t * animationSpeed))*quickerMultiplier + baseSpeed, 0f, Space.World);
        transform.Translate(0f, Mathf.Cos(t * animationSpeed) * movementRange, 0f, Space.World);
    }
}

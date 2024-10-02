using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float newOrientation(float current, Vector2 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(-velocity.x, velocity.y);
        }
        
        return current;
    }
}

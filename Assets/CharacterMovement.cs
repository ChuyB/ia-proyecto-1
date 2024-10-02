using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private SteeringOutput steeringOutput = new SteeringOutput();
    private Kinematic kinematic = new Kinematic();

    // Start is called before the first frame update
    void Start()
    {
        kinematic.position = new Vector2(0, 0);
        kinematic.orientation = 0;
        kinematic.velocity = new Vector2(0, 0);
        kinematic.rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        kinematic.update(steeringOutput, Time.deltaTime);
        transform.position += new Vector3(kinematic.position.x, kinematic.position.y, 0);

        steeringOutput.linear = new Vector2(0, 0);
    }
}

class Kinematic
{
    public Vector2 position;
    public float orientation;
    public Vector2 velocity;
    public float rotation;

    public void update(SteeringOutput steering, float time)
    {
        position += velocity * time;
        orientation += rotation * time;

        velocity += steering.linear * time;
        rotation += steering.angular * time;
    }
}

class SteeringOutput
{
    public Vector2 linear = new Vector2(0,0);
    public float angular = 0;
}

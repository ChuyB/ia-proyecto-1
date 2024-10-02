using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Wanderer : Static
{
    private KinematicWander kinematicWander = new KinematicWander();
    private KinematicSteeringOutput kinematicSteeringOutput = new KinematicSteeringOutput();

    public float maxSpeed;
    public float maxRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        kinematicWander.character = this;
        kinematicWander.maxSpeed = maxSpeed;
        kinematicWander.maxRotation = maxRotation;

        kinematicSteeringOutput = kinematicWander.getSteering();
        transform.position += new Vector3(kinematicSteeringOutput.velocity.x, kinematicSteeringOutput.velocity.y);
        transform.Rotate(0, 0, kinematicSteeringOutput.rotation);
    }
}
class KinematicWander
{
    public Static character;
    public float maxSpeed;
    public float maxRotation;

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        result.velocity = maxSpeed * character.transform.right;

        result.rotation = Random.Range(-1.0f, 1.0f) * maxRotation;

        return result;
    }
}
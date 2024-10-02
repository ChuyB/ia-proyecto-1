using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Seeker : Static
{

    private KinematicSeek kinematicSeek = new KinematicSeek();
    private KinematicArrive kinematicArrive = new KinematicArrive();

    private KinematicSteeringOutput kinematicSteeringOutput = new KinematicSteeringOutput();
    public Static target;
    public float maxSpeed;
    public float radius;
    public float timeToTarget;
    public bool isKineticImproved;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        kinematicSeek.target = target;
        kinematicSeek.character = this;
        kinematicSeek.maxSpeed = maxSpeed;

        kinematicArrive.target = target;
        kinematicArrive.character = this;
        kinematicArrive.maxSpeed = maxSpeed;
        kinematicArrive.timeToTarget = timeToTarget;
        kinematicArrive.radius = radius;

        if (isKineticImproved)
        {
            kinematicSteeringOutput = kinematicArrive.getSteering();
            if (kinematicSteeringOutput == null)
                return;
        } else {
            kinematicSteeringOutput = kinematicSeek.getSteering();
        }
        transform.position += new Vector3(kinematicSteeringOutput.velocity.x, kinematicSteeringOutput.velocity.y);
    }
}

class KinematicSeek
{
    public Static character;
    public Static target;
    public float maxSpeed;

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.transform.position - character.transform.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        character.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * character.newOrientation(character.transform.rotation.eulerAngles.y, result.velocity));

        result.rotation = 0;
        return result;
    }
}

class KinematicArrive
{
    public Static character;
    public Static target;
    public float maxSpeed;
    public float radius;
    public float timeToTarget;

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.transform.position - character.transform.position;

        if (result.velocity.magnitude < radius)
            return null;

        result.velocity /= timeToTarget;

        if(result.velocity.magnitude > maxSpeed)
        {
            result.velocity.Normalize();
            result.velocity *= maxSpeed;
        }

        character.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * character.newOrientation(character.transform.rotation.eulerAngles.y, result.velocity));
        result.rotation = 0;
        return result;
    }
}

class KinematicSteeringOutput
{
    public Vector2 velocity;
    public float rotation;
}

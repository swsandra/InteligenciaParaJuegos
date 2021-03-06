﻿using UnityEngine;
using System.Collections;

public class Evade : DFlee
{

    Agent evadeTarget;
    float maxPrediction, speed, prediction;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        evadeTarget = target;
        target = new Agent();
        maxPrediction = 4f;
    }

    // Update is called once per frame
    new void Update()
    {
        if(!stop){
            character.SetSteering(GetSteering(), weight, priority);
        }else{
            character.SetSteering(new Steering(), weight, priority);
        }
    }

    public override Steering GetSteering()
    {
        Vector3 direction = evadeTarget.transform.position - character.transform.position;
        float distance = direction.magnitude;

        speed = character.velocity.magnitude;

        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }

        target = evadeTarget;

        target.transform.position += evadeTarget.velocity * prediction;

        return base.GetSteering();
    }
}

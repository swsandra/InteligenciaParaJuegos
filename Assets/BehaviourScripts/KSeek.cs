﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSeek : GeneralBehaviour {

    // Use this for initialization
    new void Start () {
        base.Start();
    }
    // Update is called once per frame
    new void Update () {
        character.velocity = target.transform.position - character.transform.position;
        character.velocity.Normalize();
        character.velocity *= character.maxSpeed;
    }
}

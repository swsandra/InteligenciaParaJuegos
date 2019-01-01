using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PursueState : State {

    GraphPathFollowing pathFollowing;

    float speed;

    GameObject invocant;

    List<Transition> transitions;

    public PursueState(GameObject inv, List<Transition> trans, float pursueSpeed){
        //Store path following script from gameobject
        invocant = inv;
        transitions= trans;
        name="pursue";
        pathFollowing = invocant.GetComponent<GraphPathFollowing>();
        speed = pursueSpeed;
        Debug.Log("Creating pursue state");
    }

    public override void GetAction(){
        if (invocant.name=="Monster_Anger") {
            pathFollowing.astar_target=GameObject.Find("Monster_Fear");
        }
        else if (invocant.name=="Monster_Sadness"){
            pathFollowing.astar_target=GameObject.Find("Monster_Happiness");
        }
        //Changes speed of character
        invocant.GetComponent<Agent>().maxSpeed = speed;
        invocant.GetComponent<Agent>().maxAcc = (speed*2)+10;
        //Pursues while it is in sight triangle (not implemented yet)

        //For now it just pursues after 5s of being lonely
    }
    
    public override List<Transition> GetTransitions(){
        return transitions;
    }

}
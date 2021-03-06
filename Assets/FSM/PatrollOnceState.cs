using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrollOnceState : State{

	//Patroll region, vectors indicating limits within patroll (min and max)
	Vector3[] patrollRegion;

	List<Transition> transitions;

	GraphPathFollowing pathFollowing;

	GameObject invocant;

	public PatrollOnceState(GameObject inv, List<Transition> trans){
		invocant=inv;
		transitions = trans;
		name="patrollonce";
        //Patrolling all regions
		patrollRegion = new Vector3[2];
		patrollRegion[0] = new Vector3(15f, -66f, 0f);
		patrollRegion[1] = new Vector3(124f, -19f, 0f);
		//Store path following script from gameobject
		pathFollowing = invocant.GetComponent<GraphPathFollowing>();
		pathFollowing.astar_target=null; //Set to null just in case
	}

	public override void GetAction(){
		//If path is empty, change for random target
		if (pathFollowing.path.Count==0){
			//Generate numbers between min and max
			float x = Random.Range(patrollRegion[0].x,patrollRegion[1].x);
			float y = Random.Range(patrollRegion[0].y,patrollRegion[1].y);
			//Get node of result vector
			int newTargetNode = pathFollowing.graph.GetNearestNodeByCenter(new Vector3(x, y, 0f));
			//Change astar target
			pathFollowing.ChangeEndNode(newTargetNode);
		}
	}

	public override List<Transition> GetTransitions(){
		return transitions;
	}

}
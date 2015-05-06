using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {
	protected GameFlow gameFlow;
	protected PetData petData;
	
	protected void InitState() {
		GameObject gameFlowObj = GameObject.FindGameObjectWithTag("GameFlow");
		if(gameFlowObj == null)
			throw new System.Exception("GameObject with tag GameFlow not found");
		gameFlow = gameFlowObj.GetComponent<GameFlow>();
		if(gameFlow == null)
			throw new System.Exception("GameFlow object does not have GameFlow component");
			
		GameObject petObj = GameObject.FindGameObjectWithTag("Pet");
		if(petObj != null)
			petData = petObj.GetComponent<PetData>();
		}
	
	public abstract void OnTick();
	public abstract void OnEnter(SwipeDir swipeDir);
	public abstract void OnLeave(SwipeDir swipeDir);
}

using UnityEngine;
using System.Collections;

public class BattleArenaState : State, ControllerObserver {

	void Start() {
		//PlayerData.RegisterObserver(this);
		SwipeController.RegisterObserver(this);
	}
	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
		//Pet.OnTick();
	}
	
	public void OnSwipeLeft() {
		//gameFlow.SwitchState(GameState.SKILLS, SwipeDir.LEFT);
	}
	
	public void OnSwipeRight() {
		//gameFlow.SwitchState(GameState.PLAY, SwipeDir.RIGHT);
	}
	
	public void OnSwipeUp() {
		
	}
	
	public void OnSwipeDown() {
	}
}
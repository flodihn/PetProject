using UnityEngine;
using System.Collections;

public class SkillsState : State, ControllerObserver {
	
	void Start() {
		SwipeController.RegisterObserver(this);
	}
	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
		Pet.OnTick();
	}
	
	public void OnSwipeLeft() {
		gameFlow.SwitchState(GameState.SHOP, SwipeDir.LEFT);
	}
	
	public void OnSwipeRight() {
		gameFlow.SwitchState(GameState.PICK_FIGHT, SwipeDir.RIGHT);
	}
	
	public void OnSwipeUp() {}
	public void OnSwipeDown() {}
}

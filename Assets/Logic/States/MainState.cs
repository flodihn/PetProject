using UnityEngine;
using System.Collections;

public class MainState : State, ControllerObserver {
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
	
	public void Quit() {
		Application.Quit();
	}
	
	public void OnSwipeLeft() {
		gameFlow.SwitchState(GameState.FEED, SwipeDir.LEFT);
	}
	
	public void OnSwipeRight() {
		gameFlow.SwitchState(GameState.STATS, SwipeDir.RIGHT);
	}
	
	public void OnSwipeUp() {}
	public void OnSwipeDown() {}
}

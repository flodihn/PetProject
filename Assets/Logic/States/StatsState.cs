using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsState : State, ControllerObserver, PetDataObserver {
	public Text strValText;
	public Text agiValText;
	public Text conValText;
	void Start() {
		SwipeController.RegisterObserver(this);
		OnStatChanged(Stat.STR);
		OnStatChanged(Stat.AGI);
		OnStatChanged(Stat.CON);
	}
	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
		petData.RegisterObserver(this);
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
		Pet.OnTick();
	}
	
	public void OnSwipeLeft() {
		gameFlow.SwitchState(GameState.MAIN, SwipeDir.LEFT);
	}
	
	public void OnSwipeRight() {
		gameFlow.SwitchState(GameState.PICK_ENVIRONMENT, SwipeDir.RIGHT);
	}
	
	public void OnSwipeUp() {}
	public void OnSwipeDown() {}
	
	public void OnLifeChanged() {}
	public void OnMaxLifeChanged() {}
	public void OnSpriteChanged() {}
	public void OnHungerChanged() {}
	
	public void OnStatChanged(Stat stat) {
		switch(stat) {
			case Stat.STR:
				strValText.text = petData.GetStrength().ToString();
				break;
			case Stat.AGI:
				agiValText.text = petData.GetAgility().ToString();
				break;
			case Stat.CON: default:
				conValText.text = petData.GetConstitution().ToString();
				break;
		}
	}
}

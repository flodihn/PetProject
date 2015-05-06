using UnityEngine;
using System.Collections;

public class StartState : State {	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
		
		if(PlayerHasPet()) {
			LoadPet();
			LoadPlayerData();
			gameFlow.SwitchState(GameState.MAIN, SwipeDir.LEFT);
		} else {
			gameFlow.SwitchState(GameState.CHOOSE_PET, SwipeDir.LEFT);
		}
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
	}
	
	private bool PlayerHasPet() {
		int hasPet = PlayerPrefs.GetInt("hasPet");
		if(hasPet == 0)
			return false;
		return true;
	}
	
	private void LoadPet() {
	}
	
	private void LoadPlayerData() {
	}
}

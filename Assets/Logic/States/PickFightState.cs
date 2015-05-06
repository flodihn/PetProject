﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickFightState : State, IPlayerDataObserver, ControllerObserver {
	public GameObject[] fightAreas;
	
	public GameObject[] commonEnemyButtons;
	
	void Start() {
		PlayerData.RegisterObserver(this);
		SwipeController.RegisterObserver(this);
		EnableSelectedEnemyArea();
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
		gameFlow.SwitchState(GameState.SKILLS, SwipeDir.LEFT);
	}
	
	public void OnSwipeRight() {
		gameFlow.SwitchState(GameState.PLAY, SwipeDir.RIGHT);
	}
	
	public void OnSwipeUp() {
		PlayerData.activeEnemyArea += 1;
		if(PlayerData.activeEnemyArea >= fightAreas.Length)
			PlayerData.activeEnemyArea = 0;
		EnableSelectedEnemyArea();
	}
	
	public void OnSwipeDown() {
		PlayerData.activeEnemyArea -= 1;
		if(PlayerData.activeEnemyArea < 0)
			PlayerData.activeEnemyArea = fightAreas.Length - 1;
		EnableSelectedEnemyArea();
	}
	
	void EnableSelectedEnemyArea() {
		for(int i = 0; i < fightAreas.Length; i++) {
			if(i == PlayerData.activeEnemyArea) 
				fightAreas[i].SetActive(true);
			else
				fightAreas[i].SetActive(false);
		}
	}
	
	public void OnGoldChanged() {}
	public void OnFoodChanged() {}
	public void OnToysChanged() {}
	public void OnCommonEnemyChanged() {
		Debug.Log ("Foobar");
	}
	public void OnNatureEnemyChanged() {}
	public void OnWaterEnemyChanged() {}
	public void OnFireEnemyChanged() {}
	public void OnFireElectricityChanged() {}
	
	void UpdateEnemies() {
		for(int i = 0; i < PlayerData.commonEnemies.Length; i++) {
			if(PlayerData.commonEnemies[i] == null)
				continue;
			EnemyData enemyData = PlayerData.commonEnemies[i].GetComponent<EnemyData>();
		}
	}
}

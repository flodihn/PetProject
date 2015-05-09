using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemySlots {
	SLOT1,
	SLOT2,
	SLOT3,
	SLOT4,
	ELITE_SLOT,
	SLOT5,
	SLOT6,
	SLOT7,
	SLOT8
};

public enum BossSlots {
	NATURE_BOSS = 7,
	WATER_BOSS = 5,
	FIRE_BOSS = 3,
	ELECTRICITY_BOSS = 2,
	FINAL_BOSS = 4
};

public static class PlayerData {
	public static GameObject[] foodItems = new GameObject[9]; 
	public static GameObject[] toyItems = new GameObject[9];
	public static GameObject[] commonEnemies = new GameObject[8];
	public static GameObject[] natureEnemies = new GameObject[8];
	public static GameObject[] waterEnemies = new GameObject[8];
	public static GameObject[] fireEnemies = new GameObject[8];
	public static GameObject[] electricityEnemies = new GameObject[8];
	public static GameObject commonEliteEnemy;
	public static GameObject natureEliteEnemy;
	public static GameObject waterEliteEnemy;
	public static GameObject fireEliteEnemy;
	public static GameObject electricityEliteEnemy;
	public static GameObject[] bossEnemies = new GameObject[5];
	
	public static GameObject currentFightningEnemyObj;
	public static GameObject currentDefeatedEnemyObj;
	
	public static int activeEnemyArea = 0; 
	private static int numGold = 0;
	
	private static List<IPlayerDataObserver> observers = new List<IPlayerDataObserver>();

	public static void RegisterObserver(IPlayerDataObserver observer) {
		observers.Add(observer);
	}

	public static void SetGold(int amount) {
		numGold = amount;
		CallGoldChangedInObservers();
	}
	
	public static int GetGold() {
		return numGold;
	}
	
	public static void AddGold(int amount) {
		numGold += amount;
		if(numGold < 0)
			numGold = 0;
		
		if(numGold > 999)
			numGold = 999;
		CallGoldChangedInObservers();
	}
	
	public static void AddFood(GameObject food) {
		for(int i = 0; i < foodItems.Length; i++) {
			if(foodItems[i] == null) {
				foodItems[i] = food;
				CallFoodChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(food);
	}
	
	public static void RemoveFood(GameObject food) {
		for(int i = 0; i < foodItems.Length; i++) {
			if(foodItems[i] == food) {
				foodItems[i] = null;
				CallFoodChangedInObservers();
				return;
			}
		}
	}
	
	public static void AddToy(GameObject toy) {
		for(int i = 0; i < toyItems.Length; i++) {
			if(toyItems[i] == null) {
				toyItems[i] = toy;
				CallToysChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(toy);
	}
	
	public static void RemoveToy(GameObject toy) {
		for(int i = 0; i < toyItems.Length; i++) {
			if(toyItems[i] == toy) {
				toyItems[i] = null;
				CallToysChangedInObservers();
				return;
			}
		}
	}
	
	public static void AddEnemy(GameObject enemy) {
		if(enemy.GetComponent<EnemyData>().elemental == EnemyElemental.COMMON)
			AddCommonEnemy(enemy);
		else if(enemy.GetComponent<EnemyData>().elemental == EnemyElemental.NATURE)
			AddNatureEnemy(enemy);
		else if(enemy.GetComponent<EnemyData>().elemental == EnemyElemental.WATER)
			AddWaterEnemy(enemy);
		else if(enemy.GetComponent<EnemyData>().elemental == EnemyElemental.FIRE)
			AddFireEnemy(enemy);
		else if(enemy.GetComponent<EnemyData>().elemental == EnemyElemental.ELECTRICITY)
			AddElectricityEnemy(enemy);
	}
	
	public static void RemoveEnemy(GameObject enemy) {
		/*
		for(int i = 0; i < toyItems.Length; i++) {
			if(toyItems[i] == toy) {
				toyItems[i] = null;
				//CallToysChangedInObservers();
				return;
			}
		}
		*/
	}
	
	private static void AddCommonEnemy(GameObject enemy) {
		for(int i = 0; i < commonEnemies.Length; i++) {
			if(commonEnemies[i] == null) {
				commonEnemies[i] = enemy;
				CallCommonEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	private static void AddNatureEnemy(GameObject enemy) {
		for(int i = 0; i < natureEnemies.Length; i++) {
			if(i == (int) EnemySlots.ELITE_SLOT)
				continue;
			if(natureEnemies[i] == null) {
				natureEnemies[i] = enemy;
				CallNatureEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	private static void AddWaterEnemy(GameObject enemy) {
		for(int i = 0; i < waterEnemies.Length; i++) {
			if(i == (int) EnemySlots.ELITE_SLOT)
				continue;
			if(waterEnemies[i] == null) {
				waterEnemies[i] = enemy;
				CallWaterEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	private static void AddFireEnemy(GameObject enemy) {
		for(int i = 0; i < fireEnemies.Length; i++) {
			if(i == (int) EnemySlots.ELITE_SLOT)
				continue;
			if(fireEnemies[i] == null) {
				fireEnemies[i] = enemy;
				CallFireEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	private static void AddElectricityEnemy(GameObject enemy) {
		for(int i = 0; i < electricityEnemies.Length; i++) {
			if(i == (int) EnemySlots.ELITE_SLOT)
				continue;
			if(electricityEnemies[i] == null) {
				electricityEnemies[i] = enemy;
				CallElectricityEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	private static void AddBossEnemy(GameObject enemy) {
		for(int i = 0; i < electricityEnemies.Length; i++) {
			if(electricityEnemies[i] == null) {
				electricityEnemies[i] = enemy;
				CallElectricityEnemyChangedInObservers();
				return;
			}
		}
		GameObject.Destroy(enemy);
	}
	
	public static void SetDefeatedEnemy() {
		currentDefeatedEnemyObj = currentFightningEnemyObj;
	}
	
	private static void CallGoldChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnGoldChanged();
		}
	}
	
	private static void CallFoodChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnFoodChanged();
		}
	}
	
	private static void CallToysChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnToysChanged();
		}
	}
	
	private static void CallCommonEnemyChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnCommonEnemyChanged();
		}
	}
	
	private static void CallNatureEnemyChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnNatureEnemyChanged();
		}
	}
	
	private static void CallWaterEnemyChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnWaterEnemyChanged();
		}
	}
	
	private static void CallFireEnemyChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnFireEnemyChanged();
		}
	}
	
	private static void CallElectricityEnemyChangedInObservers() {
		foreach(IPlayerDataObserver observer in observers) {
			observer.OnFireElectricityChanged();
		}
	}
}

using UnityEngine;
using System.Collections;

public class FoodInventory : MonoBehaviour, IPlayerDataObserver {

	void Start () {
		PlayerData.RegisterObserver(this);
	}
	
	public void OnGoldChanged() {}
	public void OnToysChanged() {}
	
	public void OnFoodChanged() {
		ShowFoodFromPlayerData();
	}
	
	void ShowFoodFromPlayerData() {
		foreach(GameObject food in PlayerData.foodItems) {
			if(food == null)
				continue;
			food.transform.SetParent(transform);
		}
	}
	
	public void OnCommonEnemyChanged() {}
	public void OnNatureEnemyChanged() {}
	public void OnWaterEnemyChanged() {}
	public void OnFireEnemyChanged() {}
	public void OnFireElectricityChanged() {}
}

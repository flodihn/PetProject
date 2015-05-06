using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldDisplay : MonoBehaviour, IPlayerDataObserver {
	public Text text;
	
	void Start() {
		PlayerData.RegisterObserver(this);
	}
	
	public void OnGoldChanged() {
		text.text = PlayerData.GetGold().ToString();	
	}
	
	public void OnFoodChanged() {}
	public void OnToysChanged() {}
	
	public void OnCommonEnemyChanged() {}
	public void OnNatureEnemyChanged() {}
	public void OnWaterEnemyChanged() {}
	public void OnFireEnemyChanged() {}
	public void OnFireElectricityChanged() {}
}

using UnityEngine;
using System.Collections;

public class ToyInventory : MonoBehaviour, IPlayerDataObserver {	
		void Start () {
			PlayerData.RegisterObserver(this);
		}
		
		public void OnGoldChanged() {}
		public void OnFoodChanged() {}
		
		public void OnToysChanged() {
			ShowToysFromPlayerData();
		}
		
		
		void ShowToysFromPlayerData() {
			foreach(GameObject toy in PlayerData.toyItems) {
				if(toy == null)
					continue;
				toy.transform.SetParent(transform);
			}
		}
		
		public void OnCommonEnemyChanged() {}
		public void OnNatureEnemyChanged() {}
		public void OnWaterEnemyChanged() {}
		public void OnFireEnemyChanged() {}
		public void OnFireElectricityChanged() {}
	}
	
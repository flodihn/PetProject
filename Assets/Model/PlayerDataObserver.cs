using UnityEngine;
using System.Collections;

public interface IPlayerDataObserver {

	void OnGoldChanged();
	void OnFoodChanged();
	void OnToysChanged();
	void OnCommonEnemyChanged();
	void OnNatureEnemyChanged();
	void OnWaterEnemyChanged();
	void OnFireEnemyChanged();
	void OnFireElectricityChanged();
}

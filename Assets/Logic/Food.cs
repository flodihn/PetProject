using UnityEngine;
using System.Collections;

public static class Food {

	private static PetData petData;

	public static void Eat(ConsumableData foodData) {
		FindAndAssignPetData();
		CreateConsumeFoodEffect();
		petData.AddHunger(-foodData.quality);
		PlayerData.RemoveFood(foodData.gameObject);
		GameObject.Destroy(foodData.gameObject);
	}
	
	private static void FindAndAssignPetData() {
		if(petData != null)
			return;
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
	}
	
	private static void CreateConsumeFoodEffect() {
		GameObject consumeFoodPrefab = petData.consumeFoodPrefab;
		if(consumeFoodPrefab == null)
			return;
		
		GameObject petRenderer = GameObject.FindGameObjectWithTag("PetRenderer");
		if(petRenderer == null)
			return;
		
		GameObject foodEffect = (GameObject) GameObject.Instantiate(
			consumeFoodPrefab,
			petRenderer.transform.position,
			Quaternion.identity);
		foodEffect.transform.SetParent(petRenderer.transform, true);
			
	}
}

using UnityEngine;
using System.Collections;

public static class Toy {

	private static PetData petData;

	public static void Play(ConsumableData toyData) {
		FindAndAssignPetData();
		CreateConsumeToyEffect();
		//petData.AddHunger(-foodData.quality);
		PlayerData.RemoveToy(toyData.gameObject);
		GameObject.Destroy(toyData.gameObject);
	}
	
	private static void FindAndAssignPetData() {
		if(petData != null)
			return;
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
	}
	
	private static void CreateConsumeToyEffect() {
		GameObject consumeToyPrefab = petData.consumeToyPrefab;
		if(consumeToyPrefab == null)
			return;
		
		GameObject petRenderer = GameObject.FindGameObjectWithTag("PetRenderer");
		if(petRenderer == null)
			return;
		
		GameObject toyEffect = (GameObject) GameObject.Instantiate(
			consumeToyPrefab,
			petRenderer.transform.position,
			Quaternion.identity);
		toyEffect.transform.SetParent(petRenderer.transform, true);
	}
}

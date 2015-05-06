using UnityEngine;
using System.Collections;

public static class Pet {
	public static GameObject pet;
	public static GameObject petRendererObj;
	public static PetData petData;
	public static PetRenderer petRenderer;
	
	static float currentHeartBeat;
	
	public static void OnTick() {
		if(petData == null)
			return;
			
		if(!petData.hasHatched)
			ProgressHatching();
		
		HeartBeat();
	}
	
	public static void ProgressHatching() {
		petData.timeUntilHatch = petData.timeUntilHatch - Time.deltaTime;
		if(petData.timeUntilHatch < 0.0f) {
			Hatch();
		}
	}
	
	public static void Setup() {
		FindAndAssignPetData();
		FindAndAssignPetRenderer();
		pet.transform.localScale = new Vector3(petData.currentSize, petData.currentSize, 1);
		pet.transform.position = petData.currentPos;
		
		foreach(GameObject eggPart in petData.eggParts) {
			if(eggPart == null)
				continue;
			eggPart.transform.SetParent(petRenderer.gameObject.transform, true);
		}
	}
	
	public static void Hatch() {
		foreach(GameObject eggPart in petData.eggParts) {
			if(eggPart == null)
				continue;
			Vector2 randomDir = new Vector2(
				Random.Range(-1.0f, 1.0f),
				Random.Range(-1.0f, 1.0f)); 
			eggPart.GetComponent<EggPart>().Explode(randomDir);
			GameObject.Destroy(eggPart, 10.0f);
		}
		petData.hasHatched = true;
		petData.SetCurrentSprite(PetSprite.DEFAULT);
	}
	
	private static void FindAndAssignPetData() {
		if(pet == null)
			pet = GameObject.FindGameObjectWithTag("Pet");
		
		petData = pet.GetComponent<PetData>();
	}
	
	private static void FindAndAssignPetRenderer() {
		if(petRendererObj == null)
			petRendererObj = GameObject.FindGameObjectWithTag("PetRenderer");
		
		petRenderer = petRendererObj.GetComponent<PetRenderer>();
	}
	
	private static void HeartBeat() {
		currentHeartBeat += Time.deltaTime;
		if(currentHeartBeat < petData.heartBeat)
			return;
		
		petData.AddHunger(1);
		currentHeartBeat = 0.0f;
	}
}

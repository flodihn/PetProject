using UnityEngine;
using System.Collections;

public class ChoosePetState : State {
	public Transform eggParent;
	
	public GameObject petRendererPrefab;
	
	public GameObject fishEggPrefab;
	public GameObject lizardEggPrefab;
	public GameObject mammalEggPrefab;
	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
	}
	
	public void SelectFishEgg() {
		GameObject pet = (GameObject) Instantiate(fishEggPrefab, Vector3.zero, Quaternion.identity);
		SetupPetAndSwitchToMainScreen(pet);
	}
	
	public void SelectLizardEgg() {
		GameObject pet = (GameObject) Instantiate(lizardEggPrefab, Vector3.zero, Quaternion.identity);
		SetupPetAndSwitchToMainScreen(pet);
	}
	
	public void SelectMammalEgg() {
		GameObject pet = (GameObject) Instantiate(mammalEggPrefab, Vector3.zero, Quaternion.identity);
		SetupPetAndSwitchToMainScreen(pet);
	}
	
	public void SetupPetAndSwitchToMainScreen(GameObject pet) {
		GameObject petRenderer = (GameObject) Instantiate(petRendererPrefab, Vector3.zero, Quaternion.identity);
		
		Pet.Setup();
		
		petRenderer.transform.SetParent(eggParent, false);
		petRenderer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -232);
		gameFlow.SwitchState(GameState.MAIN, SwipeDir.LEFT);
	}
}

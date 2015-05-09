using UnityEngine;
using System.Collections;

public enum GameState {
	START,
	CHOOSE_PET,
	MAIN,
	FEED,
	SLEEP,
	PLAY,
	PICK_FIGHT,
	SKILLS,
	SHOP,
	PICK_ENVIRONMENT,
	STATS,
	BATTLE_ARENA,
	PICK_REWARD
};

public enum PetMood {
	HAPPY,
	SAD,
	HUNGRY,
	STARVING,
	BORED,
	TIRED	
};

public enum SwipeDir {
	LEFT,
	RIGHT
};

public class GameFlow : MonoBehaviour {
	public GameObject startState;
	public GameObject choosePetState;
	public GameObject mainState;
	public GameObject feedState;
	public GameObject sleepState;
	public GameObject playState;
	public GameObject pickFightState;
	public GameObject skillsState;
	public GameObject shopState;
	public GameObject pickEnvironmentState;
	public GameObject statsState;
	public GameObject battleArenaState;
	public GameObject pickRewardState;
	
	private GameObject stateToSwitchOnNextFrame = null;
	private GameObject currentStateObj = null;
	private State currentState = null;
	private SwipeDir swipeDir;
	
	
	void Start() {
		SwitchState(GameState.START, SwipeDir.LEFT);
		
		startState.SetActive(false);
		choosePetState.SetActive(false);
		mainState.SetActive(false);
		feedState.SetActive(false);
		sleepState.SetActive(false);
		playState.SetActive(false);
		pickFightState.SetActive(false);
		skillsState.SetActive(false);
		shopState.SetActive(false);
		pickEnvironmentState.SetActive(false);
		battleArenaState.SetActive(false);
		pickRewardState.SetActive(false);
	}
	
	void Update() {
	
		if(stateToSwitchOnNextFrame != null) {
			HandleEnterNewState();
		}
		
		if(currentState == null)
			return;
			
		currentState.OnTick();
		SwipeController.OnTick();
	}
	
	public void SwitchState(GameState newState, SwipeDir _swipeDir) {
		swipeDir = _swipeDir;
		switch(newState) {
			case GameState.START:
				stateToSwitchOnNextFrame = startState;
				break;
			case GameState.CHOOSE_PET: 
				stateToSwitchOnNextFrame = choosePetState;
				break;
			case GameState.FEED:
				stateToSwitchOnNextFrame = feedState;
				break;
			case GameState.SLEEP:
				stateToSwitchOnNextFrame = sleepState;
				break;
			case GameState.PLAY:
				stateToSwitchOnNextFrame = playState;
				break;
			case GameState.PICK_FIGHT:
				stateToSwitchOnNextFrame = pickFightState;
				break;
			case GameState.SKILLS:
				stateToSwitchOnNextFrame = skillsState;
				break;
			case GameState.SHOP:
				stateToSwitchOnNextFrame = shopState;
				break;
			case GameState.PICK_ENVIRONMENT:
				stateToSwitchOnNextFrame = pickEnvironmentState;
				break;
			case GameState.STATS:
				stateToSwitchOnNextFrame = statsState;
				break;
			case GameState.BATTLE_ARENA:
				stateToSwitchOnNextFrame = battleArenaState;
				break;
			case GameState.PICK_REWARD:
				stateToSwitchOnNextFrame = pickRewardState;
				break;
		case GameState.MAIN: default:
				stateToSwitchOnNextFrame = mainState;
				break;
		}
	}
	
	void HandleEnterNewState() {
		if(currentState != null) {
			currentState.OnLeave(swipeDir);
			currentStateObj.SetActive(false);
		}
		currentStateObj = stateToSwitchOnNextFrame;
		stateToSwitchOnNextFrame = null;
		currentStateObj.SetActive(true);
		currentState = currentStateObj.GetComponent<State>();
		currentState.OnEnter(swipeDir);
		
	}
	
	public GameObject GetCurrentState() {
		return currentStateObj;
	}
}

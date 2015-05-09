using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickRewardState : State, ControllerObserver {
	public GameObject rewardPanel;
	public GameObject goldReward;
	public GameObject smallSkillReward;
	public GameObject largeSkillReward;

	void Start() {
		SwipeController.RegisterObserver(this);
	}
	
	public override void OnEnter(SwipeDir swipeDir) {
		base.InitState();
		StartCoroutine(AddRewards(1.0F));
	}
	
	public override void OnLeave(SwipeDir swipeDir) {
	}
	
	public override void OnTick() {
		//Pet.OnTick();
		//AddRewards();
	}
	
	public void OnSwipeLeft() {
	}
	
	public void OnSwipeRight() {
	}
	
	public void OnSwipeUp() {
	}
	
	public void OnSwipeDown() {
	}
	
	IEnumerator AddRewards(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		rewardPanel.GetComponent<AddRewards>().enabled = true;
	}
	
	private void AddGoldReward() {
		GameObject reward = (GameObject) Instantiate(goldReward, Vector3.zero, Quaternion.identity);
		//rewardPanel.GetComponent<VerticalLayoutGroup>().
		//reward.GetComponent<RectTransform>().SetParent(rewardPanel.GetComponent<RectTransform>());
	}
	
	private void AddSmallSkillReward() {
		GameObject reward = (GameObject) Instantiate(smallSkillReward, Vector3.zero, Quaternion.identity);
		//reward.GetComponent<RectTransform>().SetParent(rewardPanel.GetComponent<RectTransform>());
	}
	
	private void AddLargeSkillReward() {
		GameObject reward = (GameObject) Instantiate(largeSkillReward, Vector3.zero, Quaternion.identity);
		//reward.GetComponent<RectTransform>().SetParent(rewardPanel.GetComponent<RectTransform>());
	}
}
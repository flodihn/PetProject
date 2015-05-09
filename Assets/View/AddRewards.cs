using UnityEngine;
using System.Collections;

public class AddRewards : MonoBehaviour {
	public GameObject goldReward;
	public GameObject smallSkillReward;
	public GameObject largeSkillReward;
	
	
	void Start () {
		AddAllRewards();
	}
	
	private void AddAllRewards() {
		AddGoldReward();
		AddSmallSkillReward();
		AddLargeSkillReward();
	}
	
	private void AddGoldReward() {
		GameObject reward = (GameObject) Instantiate(goldReward, Vector3.zero, Quaternion.identity);
		reward.transform.SetParent(transform);
	}
	
	private void AddSmallSkillReward() {
		GameObject reward = (GameObject) Instantiate(smallSkillReward, Vector3.zero, Quaternion.identity);
		reward.transform.SetParent(transform);
	}
	
	private void AddLargeSkillReward() {
		GameObject reward = (GameObject) Instantiate(largeSkillReward, Vector3.zero, Quaternion.identity);
		reward.transform.SetParent(transform);
	}
}

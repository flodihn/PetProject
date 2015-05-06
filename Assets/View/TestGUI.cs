using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour {
	public GameObject[] toyItems;
	public GameObject[] foodItems;
	public GameObject[] commonEnemies;
	PetData petData;
	
	public void AddGold(int amount) {
		PlayerData.AddGold(amount);
	}
	
	public void AddLife(int amount) {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.AddLife(amount);
	}
	
	public void AddMaxLife(int amount) {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.AddMaxLife(amount);
	}
	
	public void AddStr(int amount) {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.AddStrength(amount);
	}
	
	public void AddAgi(int amount) {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.AddAgility(amount);
	}
	
	public void AddCon(int amount) {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.AddConstitution(amount);
	}
	
	public void AddFood() {
		GameObject food = (GameObject) Instantiate(
			foodItems[Random.Range(0, foodItems.Length)],
			Vector3.zero,
			Quaternion.identity);
		PlayerData.AddFood(food);
	}
	
	public void AddToy() {
		GameObject toy = (GameObject) Instantiate(
			toyItems[Random.Range(0, toyItems.Length)],
			Vector3.zero,
			Quaternion.identity);
		PlayerData.AddToy(toy);
	}
	
	public void AddCommonEnemy() {
		GameObject enemy = (GameObject) Instantiate(
			commonEnemies[Random.Range(0, commonEnemies.Length)],
			Vector3.zero,
			Quaternion.identity);
		PlayerData.AddEnemy(enemy);
	}
	
}

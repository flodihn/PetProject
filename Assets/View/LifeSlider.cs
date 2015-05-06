using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeSlider : MonoBehaviour, PetDataObserver {
	public Slider slider;
	PetData petData;
	
	void Start() {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.RegisterObserver(this);
		
		slider.value = petData.GetLife();
		slider.maxValue = petData.GetMaxLife();
	}
	
	public void OnLifeChanged() {
		slider.value = petData.GetLife();
	}
	
	public void OnMaxLifeChanged() {
		slider.maxValue = petData.GetMaxLife();
	}
	
	public void OnSpriteChanged() {} 
	public void OnHungerChanged() {}
	public void OnStatChanged(Stat stat) {}
}

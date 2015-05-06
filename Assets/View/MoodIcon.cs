using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoodIcon : MonoBehaviour, PetDataObserver {
	public Image iconSprite;
	public Sprite happyIcon;
	public Sprite hungryIcon;
	public Sprite starvingIcon;
	
	PetData petData;
	
	void Start() {
		petData = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetData>();
		petData.RegisterObserver(this);
	}
	
	public void OnHungerChanged() {
		PetHunger hunger = petData.GetHunger();
		switch(hunger) {
			case PetHunger.SATED:
				iconSprite.sprite = happyIcon;
				break;
			case PetHunger.HUNGRY:
				iconSprite.sprite = hungryIcon;
				break;
			case PetHunger.STARVING: default:
				iconSprite.sprite = starvingIcon;
				break;
		}
	}
	
	public void OnLifeChanged() {}
	public void OnMaxLifeChanged() {}
	public void OnSpriteChanged() {}
	public void OnStatChanged(Stat stat) {}
}

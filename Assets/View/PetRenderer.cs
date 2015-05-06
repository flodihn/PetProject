using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetRenderer : MonoBehaviour, PetDataObserver {
	private Image image;
	private PetData petData;
	private Sprite[] sprites;
	
	void Start() {
		GameObject petObj = GameObject.FindGameObjectWithTag("Pet");
		petData = petObj.GetComponent<PetData>();
		petData.RegisterObserver(this);
		image = GetComponent<Image>();
		SetupSpriteSheet();
		image.sprite = sprites[(int) petData.currentSprite];
	}
	
	void SetupSpriteSheet() {
		sprites = Resources.LoadAll(petData.spriteSheet, typeof(Sprite)).Cast<Sprite>().ToArray();
		
		if(sprites == null)
			Debug.Log("FAILED TO LOAD SPRITESHEET");
		else
			Debug.Log("Loaded " + sprites.Count().ToString() + " sprites.");
	}
	
	public void OnSpriteChanged() {
		image.sprite = sprites[(int) petData.currentSprite];
	}
	
	public void OnLifeChanged() {}
	public void OnMaxLifeChanged() {}
	public void OnHungerChanged() {}
	public void OnStatChanged(Stat stat) {}
}

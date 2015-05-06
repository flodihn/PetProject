using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PetSprite {
	EMPTY = 0,
	DEFAULT = 1
};

public enum PetHunger {
	SATED,
	HUNGRY,
	STARVING
};

public enum Stat {
	STR,
	AGI,
	CON
};

public class PetData : MonoBehaviour {
	public PetSprite currentSprite = PetSprite.EMPTY;
	public string spriteSheet;
	public GameObject consumeFoodPrefab;
	public GameObject consumeToyPrefab;
	public GameObject[] eggParts = new GameObject[9];
	public const float minSize = 0.5f;
	public const float maxSize = 2.0f;
	public const float sizeSmall = 0.5f;
	public const float sizeNormal = 1.0f;
	public const float sizeLarge = 1.6f;
	
	public float heartBeat = 1.0f;
	
	public float timeUntilHatch = 5.0f;
	public bool hasHatched = false;
	
	public float currentSize;
	public Vector3 currentPos;
	
	public int maxSatedLevel = 255;
	public int hungryLevel = 200;
	public int starvingLevel = 150;
	public int sated = 0;
	
	public bool isHungry = false;
	public bool isStarving = false;
	
	private List<PetDataObserver> observers = new List<PetDataObserver>();
	private int currentLife = 0;
	private int maxLife = 0;
	
	public int str;
	public int agi;
	public int con;
	
	void Start() {
		sated = maxSatedLevel;
	}
	
	public void RegisterObserver(PetDataObserver observer) {
		if(observers.Contains(observer))
			return;
		observers.Add(observer);
	}
	
	public void SetLife(int amount) {
		currentLife = amount;
		CallLifeChangedInObservers();
	}
	
	public void SetMaxLife(int amount) {
		maxLife = amount;
		CallMaxLifeChangedInObservers();
	}
	
	public void AddMaxLife(int amount) {
		maxLife += amount;
		CallMaxLifeChangedInObservers();
	}
	
	public void AddLife(int amount) {
		currentLife += amount;
		if(currentLife > maxLife)
			currentLife = maxLife;
			
		CallLifeChangedInObservers();
	}
	
	public int GetLife() {
		return currentLife;
	}
	
	public int GetMaxLife() {
		return maxLife;
	}
	
	public void AddHunger(int amount) {
		sated -= amount;
		if(sated > maxSatedLevel)
			sated = maxSatedLevel;
		
		if(sated <= starvingLevel) {
			isHungry = true;
			isStarving = true;
		} else if(sated <= hungryLevel) {
			isHungry = true;
			isStarving = false;
		} else {
			isHungry = false;
			isStarving = false;
		}
			
		CallHungerChangedInObservers();
	}
	
	public PetHunger GetHunger() {
		if(sated <= starvingLevel)
			return PetHunger.STARVING;
		if(sated <= hungryLevel)
			return PetHunger.HUNGRY;
		return PetHunger.SATED;
	}
	
	public void SetCurrentSprite(PetSprite newSprite) {
		currentSprite = newSprite;
		CallSpriteChangedInObservers();
	}
	
	public void SetStrength(int amount) {
		str = amount;
		CallStatChangedInObservers(Stat.STR);
	}
	
	public void SetAgility(int amount) {
		agi = amount;
		CallStatChangedInObservers(Stat.AGI);
	}
	
	public void SetConstitution(int amount) {
		con = amount;
		CallStatChangedInObservers(Stat.STR);
	}
	
	public void AddStrength(int amount) {
		str += amount;
		CallStatChangedInObservers(Stat.STR);
	}
	
	public void AddAgility(int amount) {
		agi += amount;
		CallStatChangedInObservers(Stat.AGI);
	}
	
	public void AddConstitution(int amount) {
		con += amount;
		CallStatChangedInObservers(Stat.CON);
	}
	
	public int GetStrength() {
		return str;
	}
	
	public int GetAgility() {
		return agi;
	}
	
	public int GetConstitution() {
		return con;
	}
	
	private void CallLifeChangedInObservers() {
		foreach(PetDataObserver observer in observers) {
			observer.OnLifeChanged();
		}
	}
	
	private void CallMaxLifeChangedInObservers() {
		foreach(PetDataObserver observer in observers) {
			observer.OnMaxLifeChanged();
		}
	}
	
	private void CallSpriteChangedInObservers() {
		foreach(PetDataObserver observer in observers) {
			observer.OnSpriteChanged();
		}
	}
	
	private void CallHungerChangedInObservers() {
		foreach(PetDataObserver observer in observers) {
			observer.OnHungerChanged();
		}
	}
	
	private void CallStatChangedInObservers(Stat stat) {
		foreach(PetDataObserver observer in observers) {
			observer.OnStatChanged(stat);
		}
	}
}

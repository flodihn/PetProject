using UnityEngine;
using System.Collections;

public interface PetDataObserver {
	void OnLifeChanged();
	void OnMaxLifeChanged();
	void OnSpriteChanged();
	void OnHungerChanged();
	void OnStatChanged(Stat stat);
}

using UnityEngine;
using System.Collections;

public enum ConsumableType {
	FOOD,
	TOY
};

public class ConsumableData: MonoBehaviour {
	public ConsumableType type;
	public int quality = 900;
	public string sprite;
}
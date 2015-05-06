using UnityEngine;
using System.Collections;

public enum EnemyElemental {
	COMMON,
	NATURE,
	WATER,
	ELECTRICITY,
	FIRE
};

public enum EnemyType {
	COMMON,
	ELITE,
	BOSS
}

public class EnemyData : MonoBehaviour {

	public string sprite;
	
	public EnemyElemental elemental;
	public EnemyType type;
	public int str;
	public int agi;
	public int con;
}

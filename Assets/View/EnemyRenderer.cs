using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyRenderer : MonoBehaviour {
	private Image image;
	private EnemyData data;
	
	void Start() {
		image = GetComponent<Image>();
		data = PlayerData.currentFightningEnemyObj.GetComponent<EnemyData>();
		image.sprite = Resources.Load(data.sprite, typeof(Sprite)) as Sprite;
	}
}
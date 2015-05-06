using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConsumableRenderer : MonoBehaviour {
	private Image image;
	private ConsumableData data;
	
	void Start() {
		image = GetComponent<Image>();
		data = GetComponent<ConsumableData>();
		image.sprite = Resources.Load(data.sprite, typeof(Sprite)) as Sprite;
	}
}

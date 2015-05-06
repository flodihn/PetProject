using UnityEngine;
using System.Collections;

public class EggPart : MonoBehaviour {
	private Vector2 explodeDir;
	private bool isExploding = false;
	private RectTransform rectTransform;
	
	public void Explode(Vector2 _explodeDir) {
		explodeDir = new Vector2(_explodeDir.x, _explodeDir.y).normalized;
		isExploding = true;
		rectTransform = GetComponent<RectTransform>();
	}
	
	void Update() {
		if(!isExploding)
			return;
		rectTransform.anchoredPosition += (explodeDir * Time.deltaTime * 500);
		transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime * 10);
	}
}

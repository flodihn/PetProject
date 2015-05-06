using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {

	void Start () {
		GameObject.Destroy(gameObject, 0.75f);	
	}
	
	void Update () {
		transform.localPosition += new Vector3(0, 500, 0) * Time.deltaTime;
	}
}

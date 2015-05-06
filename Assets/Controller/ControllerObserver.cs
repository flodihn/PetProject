using UnityEngine;
using System.Collections;

public interface ControllerObserver {

	void OnSwipeLeft();
	void OnSwipeRight();
	void OnSwipeUp();
	void OnSwipeDown();
}

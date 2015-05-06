using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SwipeController {
	public static bool swipingEnabled = true;
	private static List<ControllerObserver> observers = new List<ControllerObserver>();
	private static GameFlow gameFlow;
	private static float timeSinceLastSwipe = 0.0f;
	
	public static void RegisterObserver(ControllerObserver observer) {
		if(gameFlow == null) {
			gameFlow = GameObject.FindGameObjectWithTag("GameFlow").GetComponent<GameFlow>();
		}
		observers.Add(observer);
	}
	
	public static void OnTick() {
		if(!swipingEnabled)
			return;
		
		IncrementTimeSinceLastSwipe();
		
		if(!IsSwipeInProgress())
			return;	
		
		Vector2 deltaMove = GetSwipeDeltaMovement();
		
		if(DetectHorizontalSwipe(deltaMove))
			HandleHorizontalSwipe(deltaMove);
		else if(DetectVerticalSwipe(deltaMove))
			HandleVerticalSwipe(deltaMove);
	}
	
	private static void IncrementTimeSinceLastSwipe() {
		timeSinceLastSwipe += Time.deltaTime;
	}
	
	private static bool IsSwipeInProgress() {
		if(timeSinceLastSwipe < 0.25f)
			return false;
		
		if(GetNumberOfTouches() != 1) 
			return false;
		if(Input.touches[0].phase != TouchPhase.Moved)
			return false;
		return true;
	}
	
	private static Vector2 GetSwipeDeltaMovement() {
		Vector2 deltaMove;
		deltaMove = Input.touches[0].deltaPosition / Input.touches[0].deltaTime;
		return deltaMove;
	}
	
	private static bool DetectHorizontalSwipe(Vector2 deltaMove) {
		if(Mathf.Abs(deltaMove.x) > 1500.0f)
			return true;
		return false;
	}
	
	private static bool DetectVerticalSwipe(Vector2 deltaMove) {
		if(Mathf.Abs(deltaMove.y) > 1500.0f)
			return true;
		return false;
	}
	
	public static void HandleHorizontalSwipe(Vector2 deltaMove) {
		if(deltaMove.x < 0)
			CallSwipeLeftInObservers();
		else
			CallSwipeRightInObservers();
		timeSinceLastSwipe = 0.0f;
	}
	
	public static void HandleVerticalSwipe(Vector2 deltaMove) {
		if(deltaMove.y < 0)
			CallSwipeUpInObservers();
		else
			CallSwipeDownInObservers();
		timeSinceLastSwipe = 0.0f;
	}
	
	private static int GetNumberOfTouches() {
		return Input.touches.Length;
	}
	
	private static void CallSwipeLeftInObservers() {
		foreach(ControllerObserver observer in observers) {
			MonoBehaviour observerMonoScript = (MonoBehaviour) observer;
			bool isStateActive = observerMonoScript.gameObject.activeInHierarchy;
			
			if(isStateActive)
				observer.OnSwipeLeft();
		}
	}
	
	private static void CallSwipeRightInObservers() {
		foreach(ControllerObserver observer in observers) {
			MonoBehaviour observerMonoScript = (MonoBehaviour) observer;
			if(observerMonoScript.gameObject == gameFlow.GetCurrentState())
				observer.OnSwipeRight();
		}
	}
	
	private static void CallSwipeUpInObservers() {
		foreach(ControllerObserver observer in observers) {
			MonoBehaviour observerMonoScript = (MonoBehaviour) observer;
			bool isStateActive = observerMonoScript.gameObject.activeInHierarchy;
			
			if(isStateActive)
				observer.OnSwipeUp();
		}
	}
	
	private static void CallSwipeDownInObservers() {
		foreach(ControllerObserver observer in observers) {
			MonoBehaviour observerMonoScript = (MonoBehaviour) observer;
			if(observerMonoScript.gameObject == gameFlow.GetCurrentState())
				observer.OnSwipeDown();
		}
	}
}

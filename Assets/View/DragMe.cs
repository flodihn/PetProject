using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public bool dragOnSurfaces = true;
	private RectTransform draggingPlane;
	private Vector3 origPos;

	public void OnBeginDrag(PointerEventData eventData)
	{
		SwipeController.swipingEnabled = false;
		
		origPos = transform.localPosition;
		Canvas canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null)
			return;
				
		SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData data)
	{
		SetDraggedPosition(data);
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
			draggingPlane = data.pointerEnter.transform as RectTransform;
			
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlane, data.position, data.pressEventCamera, out globalMousePos))
		{
			transform.position = globalMousePos;
			transform.rotation = draggingPlane.rotation;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		SwipeController.swipingEnabled = true;
		transform.localPosition = origPos;
	}

	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();

		if (comp != null)
			return comp;
		
		Transform t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}

using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Button activateButton;

	public string modelKeyOnDrop;

	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;

	public GameObject callBackObj;
	public string callBackFun;
	public int callBackArg;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
		SwipeController.swipingEnabled = true;
		ConsumableData consumableData = data.pointerDrag.GetComponent<ConsumableData>();
		
		switch(consumableData.type) {
			case ConsumableType.FOOD:
				Food.Eat(consumableData);
				break;
			case ConsumableType.TOY:
				Toy.Play(consumableData);
				break;
			default:
				break;
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

		var srcImage = originalObj.GetComponent<Image>();
		return srcImage.sprite;
	}
}

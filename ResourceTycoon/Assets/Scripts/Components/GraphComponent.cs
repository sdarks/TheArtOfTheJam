using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphComponent : BaseComponent
{
	public float ElementPadding;
	public float OuterBackgroundPadding;
	public float LineWidth;
	public float PointRadius;

	public Sprite PointSprite;
	public Sprite LineSprite;
	public Image OuterBackground;
	public Image InnerBackground;
	public RectTransform GraphBox;
	public RectTransform OverallTransform;
	public RectTransform GraphHolder;
	public RectTransform PointHolder;
	public RectTransform LineHolder;
	public GameObject PointTemplate;
	public GameObject LineTemplate;
	public float temp;

	public Vector2 XMinMax;
	public Vector2 YMinMax;
	public Vector2 WidthHeight;

	public List<Vector2> GraphPoints = new List<Vector2>();
}

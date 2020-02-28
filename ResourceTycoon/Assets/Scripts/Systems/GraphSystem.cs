using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(GraphComponent));
	}


	public override void SystemUpdate( Archetype Arc )
	{
		//Get the list of components in this archetype
		List<BaseComponent> GraphComponents = Arc.Components[Arc.ComponentTypeMap[typeof(GraphComponent)]];

		for (int i = 0; i < GraphComponents.Count; i++)
		{
			GraphComponent Graph = (GraphComponent)GraphComponents[i];

			//Size the entire graph
			Graph.OverallTransform.sizeDelta = new Vector2(Graph.WidthHeight.x, Graph.WidthHeight.y);

			//Size the outer background
			Graph.GraphBox.sizeDelta = new Vector2(-Graph.OuterBackgroundPadding, -Graph.OuterBackgroundPadding);
			
			//Size the point holder
			Graph.GraphHolder.sizeDelta = new Vector2(-Graph.ElementPadding, -Graph.ElementPadding);

			//Clear Point holder
			if(Graph.PointHolder.childCount < Graph.GraphPoints.Count)
			{
				/*
				foreach (Transform child in Graph.PointHolder)
				{
					GameObject.Destroy(child.gameObject);
				}*/

				for(int j=0; j<(Graph.GraphPoints.Count-Graph.PointHolder.childCount); j++)
				{
					GameObject.Instantiate(Graph.PointTemplate, Graph.PointHolder);
				}
			}
			else
			{
				//Place the points
				for (int j = 0; j < Graph.GraphPoints.Count; j++)
				{
					RectTransform point = Graph.PointHolder.GetChild(j) as RectTransform;
					UnityEngine.UI.Image img = point.GetComponent<UnityEngine.UI.Image>();
					img.sprite = Graph.PointSprite;

					float xPos = (Graph.GraphPoints[j].x / Graph.XMinMax.y) * (Graph.WidthHeight.x - Graph.OuterBackgroundPadding - Graph.ElementPadding);
					float yPos = (Graph.GraphPoints[j].y / Graph.YMinMax.y) * (Graph.WidthHeight.y - Graph.OuterBackgroundPadding - Graph.ElementPadding);
					point.anchoredPosition = new Vector2(xPos, yPos);
					point.sizeDelta = new Vector2(Graph.PointRadius, Graph.PointRadius);
					point.anchorMin = new Vector2(0, 0);
					point.anchorMax = new Vector2(0, 0);
				}

			}


			//Clear Line holder
			if (Graph.LineHolder.childCount < Graph.GraphPoints.Count-1)
			{
				for (int j = 0; j < (Graph.GraphPoints.Count-1 - Graph.LineHolder.childCount); j++)
				{
					GameObject.Instantiate(Graph.LineTemplate, Graph.LineHolder);
				}
			}
			else
			{
				//Place the points
				for (int j = 0; j < Graph.GraphPoints.Count - 1; j++)
				{
					RectTransform Line = Graph.LineHolder.GetChild(j) as RectTransform;
					UnityEngine.UI.Image img = Line.GetComponent<UnityEngine.UI.Image>();
					img.sprite = Graph.LineSprite;


					Vector2 curPoint = (Graph.PointHolder.GetChild(j) as RectTransform).anchoredPosition;
					Vector2 nextPoint = (Graph.PointHolder.GetChild(j+1) as RectTransform).anchoredPosition;

					float distance = Vector2.Distance(curPoint, nextPoint);
					Line.anchoredPosition = curPoint+((nextPoint-curPoint)/2);
					Line.sizeDelta = new Vector2(Graph.LineWidth, distance);
					Line.anchorMin = new Vector2(0, 0);
					Line.anchorMax = new Vector2(0, 0);

					Vector3 relative = new Vector3(nextPoint.x-curPoint.x, nextPoint.y-curPoint.y, 0);
					float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
					Line.localEulerAngles = new Vector3(0,0,-angle);
				}
			}

			

		}
	}
}

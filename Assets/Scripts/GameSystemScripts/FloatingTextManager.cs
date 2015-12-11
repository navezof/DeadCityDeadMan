using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatingTextManager : MonoBehaviour
{
	/** static reference to this, accesible everywhere */
	public static FloatingTextManager 	textManager;

	/** time interval between two text */
	public float						launchInterval;

	/** Contain all the texts yet to be launched */
	private List<GameObject>			texts = new List<GameObject>();
	/** Last time a text was launched */
	private float						lastLaunch;

	void Awake()
	{
		textManager = this;
	}

	void Update()
	{
		if (texts.Count > 0 && (Time.time - lastLaunch > launchInterval))
		{
			texts[0].GetComponent<FloatingText>().Launch();
			texts.RemoveAt(0);
			lastLaunch = Time.time;
		}
	}

	public void CreateText(string text, Color color, GameObject text_prefab, Vector3 position)
	{
		GameObject newText;

		newText = (GameObject) Instantiate(text_prefab, position, new Quaternion());
		newText.GetComponent<FloatingText>().Init(text, color);
		texts.Add(newText);
	}
}

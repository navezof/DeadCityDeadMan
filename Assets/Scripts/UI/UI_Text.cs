using UnityEngine;
using System.Collections;

public class UI_Text : UI_Base
{
	public string	text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();
	}

	void OnGUI()
	{
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = -1;


	}
}

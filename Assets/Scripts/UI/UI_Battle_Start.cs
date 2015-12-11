using UnityEngine;
using System.Collections;

public class UI_Battle_Start : UI_Base
{
	void Update ()
	{
		Position();
	}

	void OnGUI()
	{
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;

		if (GUI.Button(rect_position, "Start"))
		{
			GameSystem.game.StartGame();
		}
	}
}

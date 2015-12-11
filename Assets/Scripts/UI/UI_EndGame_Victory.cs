using UnityEngine;
using System.Collections;

public class UI_EndGame_Victory : UI_Base
{
	void OnGUI()
	{
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;

		if (GameSystem.game.bVictory)
		{
			if (GameSystem.game.bVictory)
			{
				GUI.color = Color.blue;
				GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), "VICTORY");
			}
			else
			{
				GUI.color = Color.blue;
				GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), "DEFEAT!");
			}

		}
	}
}

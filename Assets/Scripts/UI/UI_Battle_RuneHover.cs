using UnityEngine;
using System.Collections;

public class UI_Battle_RuneHover : UI_Base
{
	void OnGUI()
	{
		Rune	hoveredRune;
		
		if (MouseController.mouse.hovered != null && 
		    MouseController.mouse.hovered.GetComponent<Tile>() != null &&
		    MouseController.mouse.hovered.GetComponent<Tile>().HasRune() &&
		    (hoveredRune = MouseController.mouse.hovered.GetComponent<Tile>().GetRune()) != null)
		{
			if (skin != null)
				GUI.skin = skin;
			GUI.depth = depth;
			GUI.Box(rect_position, "");
			
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width - offsetX, rect_position.height - offsetY), hoveredRune.name);
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY * 2, rect_position.width - offsetX, rect_position.height - offsetY),
			          "Life : " + hoveredRune.life + " Power : " + hoveredRune.GetPower());
		}
	}
}

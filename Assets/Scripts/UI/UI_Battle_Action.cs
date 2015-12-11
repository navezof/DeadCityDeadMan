using UnityEngine;
using System.Collections;

public class UI_Battle_Action : UI_Menu
{
	void Update ()
	{
		Position();
		PositionMenu();
	}

	void OnGUI()
	{
		Character	character;
		int index;

		if (GameSystem.game.character == null || GameSystem.game.clicked == null)
			return ;
		index = 0;
		if (GameSystem.game.character.GetActionSystem().action == null)
			character = MouseController.mouse.clickedCharacter;
		else
			character = GameSystem.game.character;
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;
		
		GUI.Box (rect_position, "");
		if (character != null)
		{
			for (int i = 0; i < character.GetActionSystem().actions.Length ; i++)
			{
				if (character.GetActionSystem().actions[i] != null)
				{
					if (character.GetActionSystem().actions[i].actionCost <= character.GetActionSystem().AP &&
					    	GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (button_interval_y * (index + 1)), button_width, button_height),
					           character.GetActionSystem().actions[i].name))
					{
						character.GetActionSystem().actions[i].Action_Start();
					}
					index++;
				}
			}
		}
	}
}

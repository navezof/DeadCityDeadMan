using UnityEngine;
using System.Collections;

public class UI_Battle_Spawn : UI_Menu
{
	Team	playerTeam;

	void Update ()
	{
		Position();
		PositionMenu();
	}

	void OnGUI()
	{
		if (!GameSystem.game.bSpawning)
			return ;
		if ((playerTeam = GameSystem.game.teams[0].GetComponent<Team>()) == null)
			return ;

		if (skin != null)
			GUI.skin = skin;
		GUI.depth = -1;
		GUI.Box (rect_position, "");

		for (int index = 0; index < playerTeam.characters.Length; index++)
		{
			if (!playerTeam.characters[index].activeSelf && GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (button_interval_y * index), button_width, button_height), playerTeam.characters[index].name))
			{
				GameSystem.game.clicked = playerTeam.characters[index].GetComponent<Character>();
				UI_Manager.UIManager.UI_Open("UI_Battle_SpawnInfo");
			}
		}
	}

}

using UnityEngine;
using System.Collections;

public class UI_TeamSelection : UI_Base
{
	private Team	team;

	public float sizeY;
	//public float offsetX;
	//public float offsetY;
	public float paddingY;

	public int	positionToSwap;

	// Use this for initialization
	void Start ()
	{
		team = GetComponent<Team>();
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
		GUI.depth = depth;
	
		GUI.Box(rect_position, name);
		for(int i = 0; i < team.characters.Length ; i++)
		{
			if (GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (i * (sizeY + paddingY)) , rect_position.width - offsetX * 2, sizeY), team.characters[i] != null ? team.characters[i].name : ""))
			{
				if (GameSystem.game.character != team.characters[i])
				{
					GameSystem.game.character = team.characters[i].GetComponent<Character>();
				}
				else
				{
					UI_Manager.UIManager.UI_Open("UI_Character_Info");
					//UI_Manager.UIManager.OpenUI(UI_Manager.EUI_Character.UI_CHARACTER_INFO, true);
				}
			}
		}
	}
}

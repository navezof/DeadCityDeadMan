using UnityEngine;
using System.Collections;

public class UI_Battle_CharacterBaseInfo : UI_Base
{
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
		if (GameSystem.game.clicked == null)
			return ;
		if (skin)
			GUI.skin = skin;
		GUI.depth = depth;
		GUI.Box(rect_position, "");

		GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width - offsetX, rect_position.height - offsetY), GameSystem.game.clicked.name);
		GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY * 2, rect_position.width - offsetX, rect_position.height - offsetY),
		          "HP : " + GameSystem.game.clicked.Health() + "/" + GameSystem.game.clicked.HealthMax());
		GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY * 3, rect_position.width - offsetX, rect_position.height - offsetY),
		          "Stamina : " + GameSystem.game.clicked.Stamina() + "/" + GameSystem.game.clicked.StaminaMax());
		GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY * 4, rect_position.width - offsetX, rect_position.height - offsetY),
		          "AP : " + GameSystem.game.clicked.ActionPoints());

	}
}

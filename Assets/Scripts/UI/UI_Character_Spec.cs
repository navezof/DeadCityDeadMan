using UnityEngine;
using System.Collections;

public class UI_Character_Spec : UI_Base
{
	public float	button_width_p;
	private float	button_width;

	public float	button_height_p;
	private float	button_height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();

		button_width = Utils.convertFromPercent(button_width_p, Screen.width);
		button_height = Utils.convertFromPercent(button_height_p, Screen.height);
	}

	void OnGUI()
	{
		if (GameSystem.game == null)
		{
			Debug.Log("game is null");
			return ;
		}
		if (GameSystem.game.character == null)
			return ;
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;

		if (GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, button_width, button_height),
		           	GameSystem.game.character.GetSpecManager().equippedSpecs[0].GetComponent<Spec>().name))
		{
			if (!GameSystem.game.bInFight)
			{
				UI_Manager.UIManager.UI_Open("UI_Character_SpecChange");
				GameUI.gameUI.specToChange = 0;
			}
			else
				UI_Battle_Notification.notification.AddNotification("You can't change your equipped specs during a fght", Color.red);
		}
		if (GUI.Button(new Rect(rect_position.x + offsetX + (offsetX + button_width), rect_position.y + offsetY, button_width, button_height),
		               GameSystem.game.character.GetSpecManager().equippedSpecs[1].GetComponent<Spec>().name))
		{
			if (!GameSystem.game.bInFight)
			{
				UI_Manager.UIManager.UI_Open("UI_Character_SpecChange");
				GameUI.gameUI.specToChange = 1;
			}
			else
				UI_Battle_Notification.notification.AddNotification("You can't change your equipped specs during a fght", Color.red);
		}
	}
}

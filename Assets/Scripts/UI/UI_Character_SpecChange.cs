using UnityEngine;
using System.Collections;

public class UI_Character_SpecChange : UI_Base
{
	public float	button_width_p;
	private float	button_width;
	
	public float	button_height_p;
	private float	button_height;

	// Use this for initialization
	void Start ()
	{
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
		GameObject[]	knownSpecs;

		if (GameSystem.game .character == null)
			return ;
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;

		GUI.Box(rect_position, "");

		knownSpecs = GameSystem.game .character.GetSpecManager().knownSpecs;
		for (int i = 0 ; i < knownSpecs.Length ; i++)
		{
			if (knownSpecs[i] != null && GameUI.gameUI.specToChange != -1 &&
			    GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + (offsetY * (i + 1)), button_width, button_height), knownSpecs[i].name))
			{
				GameSystem.game .character.GetSpecManager().ChangeSpec(i);
//				tmpSpec = GameSystem.game .character.GetSpecManager().equippedSpecs[GameUI.gameUI.specToChange];
//				GameSystem.game .character.GetSpecManager().equippedSpecs[GameUI.gameUI.specToChange] = knownSpecs[i];
//				knownSpecs[i] = tmpSpec;
//				GameSystem.game .character.GetBattleSystem().UpdateSheet();
//				UI_Manager.UIManager.OpenUI(UI_Manager.EUI_Character.UI_CHARACTER_SPECCHANGE, false);
			}
		}
	}
}

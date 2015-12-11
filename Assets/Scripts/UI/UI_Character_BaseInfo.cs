using UnityEngine;
using System.Collections;

public class UI_Character_BaseInfo : UI_Base
{
	// Use this for initialization
	void Start ()
	{
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

		if (GameSystem.game.character != null)
		{
			GUI.Box(rect_position, GameSystem.game.character.name + " - hp : " + GameSystem.game.character.GetHealthSystem().health +
			        "/" + GameSystem.game.character.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX));
		}
	}
}

using UnityEngine;
using System.Collections;

public class UI_Battle_SpawnInfo : UI_Base
{
	private Character character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameSystem.game.bSpawning)
			return ;
		Position ();
	}

	void OnGUI()
	{
		if (!GameSystem.game.bSpawning || GameSystem.game.clicked == null)
			return ;
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = -1;

		if ((character = GameSystem.game.clicked.GetComponent<Character>()) == null)
			return ;

		GUI.Box(rect_position, character.name + " - hp : " + character.GetHealthSystem().health +
		        "/" + character.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX));
		GUI.Box(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.y), 
		        character.GetSpecManager().equippedSpecs[0].name + (character.GetSpecManager().equippedSpecs.Length > 1 ? " / " + character.GetSpecManager().equippedSpecs[1].name : ""));
	}
}

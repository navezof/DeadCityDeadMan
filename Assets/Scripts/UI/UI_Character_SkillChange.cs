using UnityEngine;
using System.Collections;

public class UI_Character_SkillChange : UI_Menu
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();
		PositionMenu();
	}

	void OnGUI()
	{
		Spec	tmpSpec;
		int		index;

		if (GameSystem.game == null)
		{
			Debug.Log("Game is null");
			return ;
		}
		if (GameSystem.game.character == null)
			return ;

		if (skin != null)
			GUI.skin = skin;
		GUI.depth = depth;
		GUI.Box(rect_position, "");

		tmpSpec = GameSystem.game.character.GetSpecManager().equippedSpecs[GameUI.gameUI.specToChange].GetComponent<Spec>();
		GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, button_width, button_height), tmpSpec.name);
		index = 0;
		for (int i = 0; i < tmpSpec.GetSkillManager().knownSkills.Length; i++)
		{
			if (tmpSpec.GetSkillManager().knownSkills[i] != null)
			{
				if (GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (button_interval_y * (index + 1)), button_width, button_height),
				               tmpSpec.GetSkillManager().knownSkills[i] != null ? tmpSpec.GetSkillManager().knownSkills[i].name : "empty"))
				{
					tmpSpec.GetSkillManager().ChangeSkill(i, GameUI.gameUI.skillToChange);
				}
				index++;
			}
		}
	}
}

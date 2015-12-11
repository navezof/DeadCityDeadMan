using UnityEngine;
using System.Collections;

public class UI_Character_Skill : UI_Menu
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
		Spec tmpSpec;

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

		GUI.Box(rect_position, "");
		for (int i = 0; i < GameSystem.game.character.GetSpecManager().equippedSpecs.Length; i++)
		{
			tmpSpec = GameSystem.game.character.GetSpecManager().equippedSpecs[i].GetComponent<Spec>();
			GUI.Label(new Rect(rect_position.x + offsetX + (i * button_interval_x), rect_position.y + offsetY, button_width, button_height), tmpSpec.name);
			for (int j = 0; j < tmpSpec.GetSkillManager().equippedSkills.Length; j++)
			{
				if (GUI.Button(new Rect(rect_position.x + offsetX + (button_interval_x * i), rect_position.y + offsetY + (button_interval_y * (j + 1)), button_width, button_height),
				               tmpSpec.GetSkillManager().equippedSkills[j] != null ? tmpSpec.GetSkillManager().equippedSkills[j].name : "empty"))
				{
					GameUI.gameUI.specToChange = i;
					GameUI.gameUI.skillToChange = j;

					if (!GameSystem.game.bInFight)
						UI_Manager.UIManager.UI_Open("UI_Character_SkillChange");
					else
						UI_Battle_Notification.notification.AddNotification("You can't change your equipped skills during a fight", Color.red);
				}
			}
		}
	}
}

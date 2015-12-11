using UnityEngine;
using System.Collections;

public class UI_Battle_Spell : UI_Menu
{
	private SpellManager	spellManager;

	void Update ()
	{
		Position();
		PositionMenu();
	}

	void OnGUI()
	{
		int index;


		if (GameSystem.game.character == null)
			return ;
		if (spellManager == null)
			spellManager = GameSystem.game.character.GetActionSystem().spec.GetSpellManager();
		index = 1;

		foreach (SpellCast s in spellManager.equipped)
		{
			if (GUI.Button(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (button_interval_y * (index + 1)), button_width, button_height),
			           s.name))
			{
				Action_SpellCast	spellcast;

				if ((spellcast = (Action_SpellCast) GameSystem.game.character.GetActionSystem().action) != null)
				{
					spellcast.InitSpell(s);
				}
			}
			index++;
		}
	}
}

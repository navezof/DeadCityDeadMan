using UnityEngine;
using System.Collections;

public class UI_Battle_CharacterHover : UI_Base
{
	public float intervalY;

	void OnGUI()
	{
        Character   hoveredCharacter;
        Guard       guard;
		float       interval;


		if (MouseController.mouse.hovered == null)
			return ;
		if (MouseController.mouse.hovered.GetComponent<Tile>() == null)
			return ;
		if (MouseController.mouse.hovered.GetComponent<Tile>().HasCharacter() &&
		    (hoveredCharacter = MouseController.mouse.hovered.GetComponent<Tile>().GetCharacter().GetComponent<Character>()) != null)
		{
			if (hoveredCharacter.gameObject.GetComponent<Rune>() != null)
				return ;

			if (skin != null)
				GUI.skin = skin;
			GUI.depth = depth;
			GUI.Box(rect_position, "");

			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width - offsetX, rect_position.height - offsetY), hoveredCharacter.name);
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY * 2, rect_position.width - offsetX, rect_position.height - offsetY),
			          hoveredCharacter.Health() + "/" + hoveredCharacter.HealthMax());

			interval = rect_position.y + offsetY + intervalY;
			foreach (GameObject g in hoveredCharacter.GetGuardManager().GetGuards())
			{
                guard = g.GetComponent<Guard>();
				interval += intervalY;
				GUI.Label(new Rect(rect_position.x + offsetX, intervalY, rect_position.width - offsetX, rect_position.height - offsetY), g.name);
			}
		}
	}
}

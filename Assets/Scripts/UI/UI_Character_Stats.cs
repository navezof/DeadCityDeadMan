using UnityEngine;
using System.Collections;

public class UI_Character_Stats : UI_Base
{
	//public float offsetX_p;
	//public float offsetY_p;
	public float column_width_p;
	public float column_height_p;
	public float paddingY_p;

	//private float offsetX;
	//private float offsetY;
	private float column_width;
	private float column_height;

	public int	column_num_element;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();

		//offsetX = Utils.convertFromPercent(offsetX_p, Screen.width);
		//offsetY = Utils.convertFromPercent(offsetY_p, Screen.height);
		
		column_width = Utils.convertFromPercent(column_width_p, Screen.width);
		column_height = Utils.convertFromPercent(column_height_p, Screen.height);		
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

		if (GameSystem.game.character)
		{
			GUI.Box(rect_position, "");
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (0 * column_height), column_width, column_height),
			          "Attack = " + GetDetailedStatValue(StatsSheet.EStats.STATS_ATTACK));
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (1 * column_height), column_width, column_height),
			          "Defense = " + GetDetailedStatValue(StatsSheet.EStats.STATS_DEFENSE));
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (2 * column_height), column_width, column_height),
			          "Health Maximum = " + GetDetailedStatValue(StatsSheet.EStats.STATS_HEALTH_MAX));
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY + (3 * column_height), column_width, column_height),
			          "Initiative = " + GetDetailedStatValue(StatsSheet.EStats.STATS_INITIATIVE));
		}
	}

	string GetDetailedStatValue(StatsSheet.EStats stat)
	{
		string detailedStatValue;
		int value;
		int v_spec1;
		int v_spec2;

		value = GameSystem.game.character.GetBattleSystem().statSheet.GetValue(stat);
		v_spec1 = GameSystem.game.character.GetSpecManager().equippedSpecs[0].GetComponent<Spec>().GetStatsSheet().GetValue(stat);
		v_spec2 = GameSystem.game.character.GetSpecManager().equippedSpecs[1].GetComponent<Spec>().GetStatsSheet().GetValue(stat);
		detailedStatValue = value + " (" + v_spec1 + " + " + v_spec2 + ")";
		return (detailedStatValue);
	}
}

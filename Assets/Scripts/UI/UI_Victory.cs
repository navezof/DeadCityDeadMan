using UnityEngine;
using System.Collections;

public class UI_Victory : UI_Base
{
	public GUISkin	title_skin;

	public float	next_x_p;
	public float	next_y_p;
	public float	next_w_p;
	public float	next_h_p;

	private Rect	next;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();
		PositionNext();

		if (Input.anyKeyDown)
		{
			print ("loading next");
			Application.LoadLevel("DCDM_m2_EndGame");
		}
	}

	void PositionNext()
	{
		next.x = Utils.convertFromPercent(next_x_p, Screen.width);
		next.y = Utils.convertFromPercent(next_y_p, Screen.height);
		next.width = Utils.convertFromPercent(next_w_p, Screen.width);
		next.height = Utils.convertFromPercent(next_h_p, Screen.height);
	}

	void OnGUI()
	{
		if (title_skin != null)
			GUI.skin = title_skin;
		GUI.depth = -3;

		if (GameSystem.game.bVictory)
		{
			GUI.color = Color.blue;
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), "VICTORY");
		}
		else
		{
			GUI.color = Color.magenta;
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), "DEFEAT!");
		}

		GUI.skin = skin;
		GUI.color = Color.white;
		GUI.Label(next, "Press any key to continue...");
	}
}

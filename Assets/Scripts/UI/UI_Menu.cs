using UnityEngine;
using System.Collections;

public class UI_Menu : UI_Base
{
	public float	button_width_p;
	protected float	button_width;
	
	public float	button_height_p;
	protected float	button_height;

	public float	button_interval_x_p;
	protected float button_interval_x;

	public float	button_interval_y_p;
	protected float	button_interval_y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void PositionMenu()
	{
		button_width = Utils.convertFromPercent(button_width_p, Screen.width);
		button_height = Utils.convertFromPercent(button_height_p, Screen.height);

		button_interval_x = Utils.convertFromPercent(button_interval_x_p, Screen.width);
		button_interval_y = Utils.convertFromPercent(button_interval_y_p, Screen.height);
	}
}

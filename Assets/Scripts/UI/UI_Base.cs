using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour
{
	public bool	bIsOpen;

	public GUISkin	skin;
	public int		depth;

	public float 	x_p;
	public float 	y_p;
	public float 	width_p;
	public float 	height_p;
	public float	offsetX_p;
	public float	offsetY_p;
	
	protected Rect	rect_position;
	protected float	offsetX;
	protected float	offsetY;

	// Use this for initialization
	void Start ()
	{
		rect_position = new Rect();
		Position();
	}

	virtual protected void Position()
	{
		rect_position.x = Utils.convertFromPercent(x_p, Screen.width);
		rect_position.y = Utils.convertFromPercent(y_p, Screen.height);
		rect_position.width = Utils.convertFromPercent(width_p, Screen.width);
		rect_position.height = Utils.convertFromPercent(height_p, Screen.height);
		offsetX = Utils.convertFromPercent(offsetX_p, Screen.width);
		offsetY = Utils.convertFromPercent(offsetY_p, Screen.height);
	}

	virtual public void OpenUI()
	{
		bIsOpen = true;
	}

	virtual public void CloseUI()
	{
		this.enabled = false;
		bIsOpen = true;
	}

	public bool IsOpen()
	{
		return (bIsOpen);
	}
}

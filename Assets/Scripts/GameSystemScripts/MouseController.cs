using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour
{
	public static MouseController	mouse;

	public int						effectZone;

	private Ray						ray;
	private RaycastHit				hit;

	public enum EMouseState
	{
		MOUSESTATE_NONE,
		MOUSESTATE_SELECTED,
		MOUSESTATE_ONGUI
	}

	public EMouseState	state;

	public GameObject	hovered;
	public Character	clickedCharacter;

	void Awake()
	{
		if (mouse != null)
			GameObject.Destroy(mouse);
		else
			mouse = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update ()
	{
		Hover();
		Click();
	}

	void Hover()
	{
		if (state == EMouseState.MOUSESTATE_ONGUI)
			return ;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000))
		{
			if (hovered != null)
				hovered.GetComponent<Tile>().OnHoverExit();
			if (hit.transform.tag == "Character")
			{
				hit.transform.GetComponent<Character>().OnHoverEnter();
				hovered = hit.transform.GetComponent<Character>().GetTile();
			}
			else if (hit.transform.tag == "Rune")
			{
				hit.transform.GetComponent<Rune>().OnHoverEnter();
				hovered = hit.transform.GetComponent<Rune>().GetTile();
			}
			else if (hit.transform.transform.tag == "Tile")
			{
				hit.transform.GetComponent<Tile>().OnHoverEnter();
				hovered = hit.transform.gameObject;
			}
		}
		else if (hovered != null)
		{
			hovered.GetComponent<Tile>().OnHoverExit();
			hovered = null;
		}
	}

//	void Hover()
//	{
//		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		if (Physics.Raycast(ray, out hit, 1000))
//		{
//			if (hovered == null)
//			{
//				if (hit.transform.tag == "Actor")
//					hovered = hit.transform.GetComponent<Character>().GetTile();
//				else if (hit.transform.transform.tag == "Tile")
//					hovered = hit.transform.gameObject;
//				hovered.GetComponent<Tile>().SetColor(Tile.EColor.COLOR_CURSOR);
//			}
//			if (hit.transform.gameObject != hovered)
//			{
//				hovered.GetComponent<Tile>().RemoveColor(Tile.EColor.COLOR_CURSOR);
//				if (hit.transform.tag == "Actor")
//				{
//					hovered = hit.transform.GetComponent<Character>().GetTile();
//				}
//				else if (hit.transform.transform.tag == "Tile")
//					hovered = hit.transform.gameObject;
//				hovered.GetComponent<Tile>().SetColor(Tile.EColor.COLOR_CURSOR);
//			}
//		}
//		else if (hovered != null)
//		{
//			hovered.GetComponent<Tile>().RemoveColor(Tile.EColor.COLOR_CURSOR);
//			hovered = null;
//		}
//	}
//

	void Click()
	{
		if (state != EMouseState.MOUSESTATE_ONGUI && Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000))
			{
				if (hit.transform.tag == "Character")
				{
					hit.transform.GetComponent<Character>().OnClick();
					clickedCharacter = hit.transform.GetComponent<Character>();
				}
			}
		}
	}

	void OnGUI()
	{
		//DEBUG_OnGUI();
	}

	void DEBUG_OnGUI()
	{
		GUI.Label(new Rect(400, 400, 200, 30), "MouseState : " + state);
		GUI.Label(new Rect(400, 430, 200, 30), "Selected : " + (hovered != null ? hovered.name : "none"));

		if (hovered != null)
		{
			for (int i = 0; i < hovered.GetComponent<Tile>().colors.Count; i++)
			{
				GUI.Label(new Rect(400, 460 + (30 * (i + 1)), 300, 30), hovered.name + " - " + hovered.GetComponent<Tile>().colors[i].ToString()); 
			}
		}
	}
}

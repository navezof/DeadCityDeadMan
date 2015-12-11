using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    public List<GameObject> occupants = new List<GameObject>();
   

    public enum EColor
	{
		COLOR_NONE,
		COLOR_CURSOR,
		COLOR_MOVE,
		COLOR_TARGET,
		COLOR_SELECTED,
	}

	//public GameObject	occupant;

	public GameObject	redTile;
	public GameObject	greenTile;
	public GameObject	blueTile;
	public GameObject	yellowTile;

	public int			positionX;
	public int 			positionY;

	public List<EColor> colors = new List<EColor>();


	// Use this for initialization
	void Start ()
	{
		SetColor(EColor.COLOR_NONE);
	}
	
	// Update is called once per frame
	void Update ()
	{
		ChangeColor(colors[colors.Count - 1]);
	}

	void ChangeColor(EColor color)
	{
		switch (color)
		{
		case EColor.COLOR_TARGET:
			redTile.renderer.enabled = true;
			greenTile.renderer.enabled = false;
			blueTile.renderer.enabled = false;
			yellowTile.renderer.enabled = false;
			break;
		case EColor.COLOR_MOVE:
			greenTile.renderer.enabled = true;
			redTile.renderer.enabled = false;
			blueTile.renderer.enabled = false;
			yellowTile.renderer.enabled = false;
			break;
		case EColor.COLOR_CURSOR:
			yellowTile.renderer.enabled = true;
			greenTile.renderer.enabled = false;
			redTile.renderer.enabled = false;
			blueTile.renderer.enabled = false;
			break;
		case EColor.COLOR_SELECTED:
			blueTile.renderer.enabled = true;
			yellowTile.renderer.enabled = false;
			greenTile.renderer.enabled = false;
			redTile.renderer.enabled = false;
			break;
		case EColor.COLOR_NONE:
			yellowTile.renderer.enabled = false;
			greenTile.renderer.enabled = false;
			redTile.renderer.enabled = false;
			blueTile.renderer.enabled = false;
			break;
		default :
			break;
		}
	}

	public void SetColor(EColor color)
	{
		foreach (EColor c in colors)
		{
			if (color == c)
				return ;
		}
		colors.Add(color);
	}
  
	public void RemoveColor(EColor color)
	{
		colors.Remove(color);
	}

    public bool AddOccupant(GameObject nOccupant)
    {
        if (nOccupant.tag == "Character" && HasCharacter())
            return (false);
        occupants.Add(nOccupant);
        return (true);

    }

    public void RemoveOccupant(GameObject nOccupant)
    {
        occupants.Remove(nOccupant);
    }

    public List<GameObject> GetOccupants()
    {
        return (occupants);
    }

    public GameObject GetCharacter()
    {
        foreach (GameObject g in occupants)
        {
            if (g.GetComponent<Character>() != null)
                return (g);
        }
        return (null);
    }

    public bool HasCharacter()
    {
        foreach (GameObject g in occupants)
        {
            if (g.GetComponent<Character>() != null)
                return (true);
        }
        return (false);
    }

    public Rune GetRune()
    {
        foreach (GameObject g in occupants)
        {
            if (g != null && g.GetComponent<Rune>() != null)
                return (g.GetComponent<Rune>());
        }
        return (null);
    }

    public bool HasRune()
    {
        foreach (GameObject g in occupants)
        {
            if (g != null && g.GetComponent<Rune>() != null)
                return (false);
        }
        return (true);
    }

    public bool IsWalkable()
    {
        foreach (GameObject g in occupants)
        {
            if (g != null && g.tag != "Rune")
                return (false);
        }
        return (true);
    }

    public bool IsEmpty()
    {
        if (occupants.Count > 0)
            return (false);
        return (true);
    }

	public void OnHoverEnter()
	{
		SetColor(EColor.COLOR_CURSOR);
	}

	public void OnHoverExit()
	{
		RemoveColor(EColor.COLOR_CURSOR);
	}

	void OnGUI()
	{
	}
}

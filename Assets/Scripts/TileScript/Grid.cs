using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
	public static Grid grid;

	public int		sizeX;
	public int		sizeY;

	private List<Tile> tiles = new List<Tile>();
	public List<Tile> GetTiles() { return tiles ; }

	void Awake()
	{
		if (grid != null)
			Destroy (grid);
		grid = this;
	}

	// Use this for initialization
	void Start ()
	{
		foreach (Transform t in transform)
		{
			tiles.Add(t.GetComponent<Tile>());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddTile(Tile tile)
	{
		tiles.Add(tile);
	}

	public void ClearTiles()
	{
		tiles.Clear();
	}

	public Tile	GetTile(int x, int y)
	{
		foreach (Tile t in tiles)
		{
			if (t.positionX == x && t.positionY == y)
			{
				return (t);
			}
		}
		return (null);
	}
}

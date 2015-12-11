using UnityEngine;
using System.Collections;
using UnityEditor;

public class TileEditor
{
	private static int tileSize = 1;
	private static int gridSizeX = 10;
	private static int gridSizeY = 10;
	
	private static string path_type1 = "Assets/Ressources/Prefabs/Tiles/Tile_Grass.prefab";
	private static string path_type2 = "Assets/Ressources/Prefabs/Tiles/Tile_Rock.prefab";
	
	private static GameObject Tile_Prefab_Grass;
	private static GameObject Tile_Prefab_Rock;
	
	[MenuItem("TileEditor/BuildGrid")]
	static void BuildGrid()
	{
		GameObject grid;
		Grid gridScript;
		
		//GameObject Tile_Prefab_Grass;
		//GameObject Tile_Prefab_Rock;
		LoadRessources();
		DestroyGrid();
		
		if (((grid = GameObject.Find("Grid")) == null) || ((gridScript = grid.GetComponent<Grid>()) == null))
		{
			Debug.LogError("ERROR : no Grid in the scene.");
			return;
		}
		
		for (int y = 0 ; y < gridSizeY ; y++)
		{
			for (int x = 0; x < gridSizeX ; x++)
			{
				GameObject tile;
				Tile		tileScript;

				if (Random.Range(0, 100) > 40)
					tile = PrefabUtility.InstantiatePrefab(Tile_Prefab_Grass as GameObject) as GameObject;
				else
					tile = PrefabUtility.InstantiatePrefab(Tile_Prefab_Rock as GameObject) as GameObject;
				tile.transform.position = new Vector3(x * tileSize, 0, y * tileSize);
				tile.name = x + "/" + y + " - Tile";

				tileScript = tile.GetComponent<Tile>();

				tileScript.positionX = x;
				tileScript.positionY = y;

				tile.transform.parent = grid.transform;
				gridScript.AddTile(tile.GetComponent<Tile>());
			}
		}		
	}
	
	static void LoadRessources()
	{
		if ((Tile_Prefab_Grass = (GameObject) AssetDatabase.LoadAssetAtPath(path_type1, typeof(GameObject))) == null)
			Debug.LogError("ERROR : can't load ressources Tile_Prefab_Grass");
		if ((Tile_Prefab_Rock = (GameObject) AssetDatabase.LoadAssetAtPath(path_type2, typeof(GameObject))) == null)
			Debug.LogError("ERROR : can't load ressources Tile_Prefab_Rock");
	}
	
	[MenuItem("TileEditor/DestroyGrid")]
	static void DestroyGrid()
	{
		GameObject grid;
		
		if ((grid = GameObject.Find("Grid")) == null)
		{
			Debug.LogWarning("WARNING : No grid to destroy");
			return ;
		}
		foreach (GameObject go in grid.transform)
		{
			GameObject.DestroyImmediate(go);
		}
		grid.GetComponent<Grid>().ClearTiles();
	}
}

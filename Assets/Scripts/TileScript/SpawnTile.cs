using UnityEngine;
using System.Collections;

public class SpawnTile : MonoBehaviour
{
	private Tile		tile;

	public GameObject	spawnTile;


	// Use this for initialization
	void Start ()
	{
		tile = GetComponent<Tile>();
	}

	void Update()
	{
		if (GameSystem.game.bSpawning)
		{
			spawnTile.renderer.enabled = true;
		}
		else
		{
			spawnTile.renderer.enabled = false;
		}
	}
}

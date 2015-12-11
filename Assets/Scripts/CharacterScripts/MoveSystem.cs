using UnityEngine;
using System.Collections;

public class MoveSystem : MonoBehaviour
{
	private Character	owner;

	public GameObject	tile;

	public int	step;

	// Use this for initialization
	void Start ()
	{
		owner = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(Tile target)
	{
        if (!target.IsWalkable())
            return;
		//target.occupant = owner.gameObject;
        target.AddOccupant(owner.gameObject);
		
		//tile.GetComponent<Tile>().occupant = null;
        tile.GetComponent<Tile>().RemoveOccupant(owner.gameObject);
        tile.GetComponent<Tile>().RemoveColor(Tile.EColor.COLOR_SELECTED);

		tile = target.gameObject;
		tile.GetComponent<Tile>().SetColor(Tile.EColor.COLOR_SELECTED);
		owner.transform.position = new Vector3(target.transform.position.x, 1, target.transform.position.z);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
	private List<GameObject>	toSpawn = new List<GameObject>();

	private GameObject 		target;
	private GameObject		targetOccupant;

	/** Raycast variable */
	private Ray 			ray;
	private	RaycastHit 		hit;

	void Start()
	{
		if (GameSystem.game.bSpawning)
		{
			foreach (GameObject c in GameSystem.game.teams[0].characters)
			{
				toSpawn.Add(c);
			}
		}
	}

	void Update()
	{
		if (!GameSystem.game.bSpawning)
			return ;
		if (Input.GetMouseButtonDown(0) && (target = GetTarget()) != null)
		{
			if (GameSystem.game.clicked == null)
			{
				UI_Battle_Notification.notification.AddNotification("Select a character to spawn first.", Color.red);
				return ;
			}
			if (target.GetComponent<SpawnTile>() == null)
			{
				UI_Battle_Notification.notification.AddNotification("You can't spawn a unit here.", Color.red);
				return ;
			}
			if ((targetOccupant = target.GetComponent<Tile>().GetCharacter()) != null)
			{
				if (GameSystem.game.teams[0].GetCharacter(targetOccupant.name) != null)
				{
					if (GameSystem.game.clicked != null)
					{
						if (GameSystem.game.clicked == targetOccupant.GetComponent<Character>())
						{
							UnSpawn(target);
						}
						else
						{
							UI_Battle_Notification.notification.AddNotification("There is already someone here.", Color.red);
							ReplaceSpawn(target);
						}
					}
					else
					{
						GameSystem.game.clicked = targetOccupant.GetComponent<Character>();
					}
				}
			}
			else
			{
				Spawn(target);
			}
		}
	}

	GameObject GetTarget()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000))
		{
			if (hit.transform.tag == "Actor")
				return (hit.transform.GetComponent<Character>().GetMoveSystem().tile);
			if (hit.transform.tag == "Tile")
				return (hit.transform.gameObject);
		}
		return (null);
	}

	void Spawn(GameObject target)
	{
		GameSystem.game.clicked.gameObject.SetActive(true);
		//GameSystem.game.clicked.Init();
		GameSystem.game.clicked.GetMoveSystem().tile = target;
		toSpawn.Remove(GameSystem.game.clicked.gameObject);
        target.GetComponent<Tile>().AddOccupant(GameSystem.game.clicked.gameObject);
		
		GameSystem.game.clicked.transform.position = new Vector3(target.transform.position.x, 1, target.transform.position.z);
		GameSystem.game.clicked = null;
		UI_Manager.UIManager.UI_Close("UI_Battle_SpawnInfo");
	}

	void UnSpawn(GameObject target)
	{
		GameSystem.game.clicked.GetMoveSystem().tile = null;
		GameSystem.game.clicked.gameObject.SetActive(false);
        target.GetComponent<Tile>().RemoveOccupant(target);
        GameSystem.game.clicked = null;
		UI_Manager.UIManager.UI_Close("UI_Battle_SpawnInfo");
	}

	void ReplaceSpawn(GameObject target)
	{
	}         
}

using UnityEngine;
using System.Collections;

/* ActionSystem
 * 
 * This class manage the start and the end of the action in actions
 * 
 */
public class ActionSystem : MonoBehaviour
{
	private Character		owner;

	/** Gameobject currently targeted */
	private GameObject		target;

	/** Raycast variable */
	private Ray 			ray;
	private	RaycastHit 		hit;

	/** number of action point that character need */
	public int 				AP;

	public int				stamina;

	/** action plugged in this character */
	public Action_Base[]	actions;

	// to render private
	/** current action */
	public Action_Base		action;
	/** current selected spec */
	public Spec				spec;
	/** current selected spell */
	public SpellCast			spell;

	// Use this for initialization
	void Start ()
	{
		owner = GetComponent<Character>();
		foreach (Action_Base act in actions)
		{
			act.SetOwner(owner);
		}
		AP = -1;
	}

	public void UpdateStaminaSystem()
	{
		if (owner)
			stamina = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX);
	}

	// Update is called once per frame
	void Update ()
	{
		if (action != null && action.bReady)
		{
            MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
			if (!action.bNeedTarget)
			{
				if (action.Action_Try(null))
					action.Action(null);
			}
			else if (Input.GetMouseButtonDown(0) && (target = GetTarget()) != null)
			{
				if (action.Action_Try(target))
					action.Action(target);
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				action.Action_Cancel();
			}
		}
	}

	void UpdateStamina()
	{
		stamina = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX);
	}

	GameObject GetTarget()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000))
		{
			if (hit.transform.tag == "Character")
				return (hit.transform.root.gameObject);
			if (hit.transform.tag == "Tile")
				return (hit.transform.gameObject);
		}
		return (null);
	}

	public void EndAction()
	{
		UI_Manager.UIManager.UI_Close("UI_Battle_Action");
		UI_Manager.UIManager.UI_Close("UI_Battle_CharacterBaseInfo");
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
		GameSystem.game.clicked = null;
		action = null;
	}
}

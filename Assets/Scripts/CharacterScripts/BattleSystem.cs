using UnityEngine;
using System.Collections;

public class BattleSystem : MonoBehaviour
{
	private Character	owner;

	public	StatsSheet	statSheet;
	
	// Use this for initialization
	void Start ()
	{
		owner = GetComponent<Character>();
		statSheet = GetComponent<StatsSheet>();
	}

	public void Init()
	{
		UpdateSheet();
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public void UpdateSheet()
	{
		if (owner == null)
			owner = GetComponent<Character>();
		if (statSheet == null)
			statSheet = GetComponent<StatsSheet>();

		statSheet.attack = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_ATTACK);
		statSheet.defense = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_DEFENSE);
		statSheet.initiative = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_INITIATIVE);
		statSheet.healthMax = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX);
		statSheet.staminaMax = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_STAMINA_MAX);

		owner.GetHealthSystem().UpdateHealthSystem();
		owner.GetActionSystem().UpdateStaminaSystem();
	}
}

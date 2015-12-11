using UnityEngine;
using System.Collections;

public class Spec : MonoBehaviour
{
	private SkillManager 	skillManager;
	private StatsSheet		statsSheet;
	private SpellManager	spellManager;
	
	public SkillManager 	GetSkillManager() { return skillManager; }
	public StatsSheet 		GetStatsSheet() { return statsSheet; }
	public SpellManager		GetSpellManager() { return spellManager; }

	// Use this for initialization
	void Start ()
	{
		skillManager = GetComponent<SkillManager>();
		statsSheet = GetComponent<StatsSheet>();
		spellManager = GetComponent<SpellManager>();
	}
}

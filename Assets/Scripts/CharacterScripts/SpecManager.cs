using UnityEngine;
using System.Collections;

public class SpecManager : MonoBehaviour
{
	private Character	owner;

	public GameObject[]	knownSpecs;
	public GameObject[] equippedSpecs;

	// Use this for initialization
	void Start ()
	{
		owner = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public int GetValue(StatsSheet.EStats stat)
	{
		int value;

		value = 0;
		foreach (GameObject spec in equippedSpecs)
			value += spec.GetComponent<StatsSheet>().GetValue(stat);
		return (value);
	}

	public void ChangeSpec(int newSpec)
	{
		GameObject tmpSpec;

		tmpSpec = equippedSpecs[GameUI.gameUI.specToChange];
		equippedSpecs[GameUI.gameUI.specToChange] = knownSpecs[newSpec];
		knownSpecs[newSpec] = tmpSpec;
		owner.GetBattleSystem().UpdateSheet();
		//UI_Manager.UIManager.OpenUI(UI_Manager.EUI_Character.UI_CHARACTER_SPECCHANGE, false);
		UI_Manager.UIManager.UI_Close("UI_Character_SpecChange");
	}
}

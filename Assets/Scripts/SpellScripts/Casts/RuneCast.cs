using UnityEngine;
using System.Collections;

public class RuneCast : SpellCast
{
	public GameObject	runePrefab;

	public override void Cast(Character caster, GameObject target)
	{
		GameObject	newRune;

		newRune = (GameObject) Instantiate(runePrefab, target.transform.position + new Vector3(0,1,0), new Quaternion());
		newRune.GetComponent<Rune>().InitRune(target);
		newRune.GetComponent<Rune>().InitSpell(caster, power, range, element, mainEffect, secondaryEffect);
	
		GameSystem.game.order.Add(newRune.GetComponent<Rune>());

		GameSystem.game.character.GetActionSystem().action.Action_End(true);
	}
}

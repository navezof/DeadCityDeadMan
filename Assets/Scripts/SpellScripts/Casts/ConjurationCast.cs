using UnityEngine;
using System.Collections;

public class ConjurationCast : SpellCast
{
	public GameObject				conjurationPrefab;

	public override void Cast(Character caster, GameObject target)
	{
		GameObject	newConjuration;
		
		newConjuration = (GameObject) Instantiate(conjurationPrefab, caster.transform.position + new Vector3(0,0.7f,0), new Quaternion());
		newConjuration.GetComponent<Conjuration>().InitSpell(caster, power, range, element, mainEffect, secondaryEffect);
		if (target.GetComponent<Character>() == null)
			newConjuration.GetComponent<Conjuration>().SetTarget(target.GetComponent<Tile>().GetCharacter().transform);
		else
			newConjuration.GetComponent<Conjuration>().SetTarget(target.transform);

		GameSystem.game.character.GetActionSystem().action.Action_End(true);
	}
}

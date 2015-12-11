using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour
{
	private Spec		specOwner;

	public SpellCast[]		known;
	public SpellCast[]		equipped;

	public int			maxConjuration;
	public int			maxRune;
	public int			maxSign;

	public void Init(Spec _specOwner)
	{
		specOwner = _specOwner;
	}

	public SpellCast		GetSpell(string name)
	{
		foreach (SpellCast s in equipped)
		{
			if (s.name == name)
				return (s);
		}
		return (null);
	}
}

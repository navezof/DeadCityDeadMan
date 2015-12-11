using UnityEngine;
using System.Collections;

public abstract class RuneEffect_Base : SpellEffect_Base
{
    protected Rune rune;
    public void SetRune(Rune newRune) { rune = newRune; }

    public override bool IsValidTarget(GameObject target)
    {
        if (!IsEmpty(target))
            return (false);
        return (true);
    }
}

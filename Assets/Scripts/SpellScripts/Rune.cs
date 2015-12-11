using UnityEngine;
using System.Collections;

public class Rune : Spell
{
	public int					life;

	public void InitRune(GameObject tile)
	{
		moveSystem = GetComponent<MoveSystem>();
		moveSystem.tile = tile;
        tile.GetComponent<Tile>().AddOccupant(this.gameObject);
	}

	public override void Activate(int actionPoinstMax)
	{
		if (life <= 0)
			Die();
		life--;
		GameSystem.game.NextCharacter();
	}

	public override void OnHoverEnter()
	{
		print ("on hover enter rune");
		UI_Manager.UIManager.UI_Open("UI_Battle_RuneHover");
		if (GetTile() != null)
			GetTile().GetComponent<Tile>().OnHoverEnter();
	}
	
	public override void OnHoverExit()
	{
		UI_Manager.UIManager.UI_Open("UI_Battle_RuneHover");
		if (GetTile() != null)
			GetTile().GetComponent<Tile>().OnHoverExit();
	}

	public override void Die()
	{
		GameSystem.game.order.Remove(this);
        GetTile().GetComponent<Tile>().RemoveOccupant(this.gameObject);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider col)
	{
		if (secondaryEffect != null && secondaryEffect.CastOn(caster, col.gameObject))
			Die ();
		if (mainEffect != null && mainEffect.CastOn(caster, col.gameObject))
			Die ();
	}

	void OnTriggerExit(Collider col)
	{
		if (secondaryEffect != null && secondaryEffect.CastOff(caster, col.gameObject))
			Die ();
        if (mainEffect != null && mainEffect.CastOff(caster, col.gameObject))
            Die();
	}
}

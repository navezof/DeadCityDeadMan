using UnityEngine;
using System.Collections;

public class Character : Actor
{
	public int				faction;

	private HealthSystem	healthSystem;
	private BattleSystem	battleSystem;
	private ActionSystem	actionSystem;
	protected MoveSystem	moveSystem;

	private SpecManager		specManager;
	private GraphicManager	graphicManager;
	private SkillManager    skillManager;

    protected GuardManager  guardManager;

	/*
	 * GETTER AND SETTER
	 */

	public HealthSystem 	GetHealthSystem() { return healthSystem; }
	public BattleSystem 	GetBattleSystem() { return battleSystem; }
	public ActionSystem		GetActionSystem() { return actionSystem; }
	public MoveSystem		GetMoveSystem() { return moveSystem; }

	public GameObject		GetTile() { return moveSystem.tile; }
	public int				GetX() { return moveSystem.tile.GetComponent<Tile>().positionX; }
	public int				GetY() { return moveSystem.tile.GetComponent<Tile>().positionY; }

	public SpecManager		GetSpecManager() { return specManager; }
	public GraphicManager	GetGraphicManager()	{ return graphicManager; }
    public GuardManager     GetGuardManager() { return guardManager; }

	public int Attack() { return battleSystem.statSheet.attack; }
	public int Defense() { return battleSystem.statSheet.defense; }
	public int Initiative() { return battleSystem.statSheet.initiative; }
	public int HealthMax() { return battleSystem.statSheet.healthMax; }
	public int Health() { return healthSystem.health; }
	public int StaminaMax() { return battleSystem.statSheet.staminaMax; }
	public int Stamina() { return actionSystem.stamina; }

	public int ActionPoints() { return actionSystem.AP; }

	public bool IsDead() { return healthSystem.bDead; }

	/*
	 * 
	 */

	void Start ()
	{
		//Init();
	}

	public void Init()
	{
		healthSystem = GetComponent<HealthSystem>();
		battleSystem = GetComponent<BattleSystem>();
		actionSystem = GetComponent<ActionSystem>();
		moveSystem = GetComponent<MoveSystem>();
		
		specManager = GetComponent<SpecManager>();
		graphicManager = GetComponent<GraphicManager>();
        guardManager = GetComponent<GuardManager>();

        healthSystem.Init();
		battleSystem.Init();
		graphicManager.Init();
	}

	virtual public void Activate(int actionPoinstMax)
	{
		if (healthSystem.bDead)
			EndTurn();
		actionSystem.enabled = true;
		actionSystem.AP = actionPoinstMax;
		guardManager.ClearGuard();
		GetTile().GetComponent<Tile>().SetColor(Tile.EColor.COLOR_SELECTED);
		//tile.GetComponent<Tile>().SetColor(Tile.EColor.COLOR_SELECTED);
	}

	/* OnClick
	 * 
	 * If there is no current action (Moving, attacking), you can click on the current character team member
	 * 
	 */
	public void OnClick()
	{
		if (!GameSystem.game.bInFight || GameSystem.game.character.GetActionSystem().action != null || MouseController.mouse.state == MouseController.EMouseState.MOUSESTATE_ONGUI)
		{
			return ;
		}
		if (faction == GameSystem.game.character.faction)
		{
			MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_ONGUI;
			GameSystem.game.clicked = this;
			UI_Manager.UIManager.UI_Close("UI_Battle_Summary");
			UI_Manager.UIManager.UI_Close("UI_Battle_DamageReport");
			UI_Manager.UIManager.UI_Open("UI_Battle_Action");
			UI_Manager.UIManager.UI_Open("UI_Battle_CharacterBaseInfo");
		}
		else
		{
			MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
			GameSystem.game.clicked = this;
			UI_Manager.UIManager.UI_Close("UI_Battle_Summary");
			UI_Manager.UIManager.UI_Close("UI_Battle_DamageReport");
			UI_Manager.UIManager.UI_Close("UI_Battle_Action");
			UI_Manager.UIManager.UI_Close("UI_Battle_CharacterBaseInfo");
		}
	}

	public virtual void OnHoverEnter()
	{
		UI_Manager.UIManager.UI_Open("UI_Battle_CharacterHover");
		if (GetTile() != null)
			GetTile().GetComponent<Tile>().OnHoverEnter();
	}

	public virtual void OnHoverExit()
	{
		UI_Manager.UIManager.UI_Close("UI_Battle_CharacterHover");
		if (GetTile() != null)
			GetTile().GetComponent<Tile>().OnHoverExit();
	}

	public void EndTurn()
	{
		UI_Manager.UIManager.UI_Close("UI_Battle_Action");
		UI_Manager.UIManager.UI_Close("UI_Battle_CharacterBaseInfo");
		UI_Manager.UIManager.UI_Close("UI_Battle_Summary");
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
		GameSystem.game.clicked = this;

		actionSystem.enabled = false;
		actionSystem.AP = -1;
		GetTile().GetComponent<Tile>().RemoveColor(Tile.EColor.COLOR_SELECTED);

		GameSystem.game.CheckObjective();
		GameSystem.game.NextCharacter();
	}

	public int GetDefaultStat(StatsSheet.EStats stat)
	{
		switch (stat)
		{
		case StatsSheet.EStats.STATS_ATTACK :
			return (battleSystem.statSheet.attack);
		case StatsSheet.EStats.STATS_DEFENSE :
			return (battleSystem.statSheet.defense);
		case StatsSheet.EStats.STATS_INITIATIVE :
			return (battleSystem.statSheet.initiative);
		case StatsSheet.EStats.STATS_HEALTH_MAX :
			return (battleSystem.statSheet.healthMax);
		default :
			return (-1);
		}
	}
}

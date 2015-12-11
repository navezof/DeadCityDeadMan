using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsSheet : MonoBehaviour
{
	public enum EStats
	{
		STATS_ATTACK,
		STATS_DEFENSE,
		STATS_INITIATIVE,
		STATS_HEALTH_MAX,
		STATS_STAMINA_MAX
	}
	
	public int		attack;
	public int		defense;
	public int		initiative;

	public int		healthMax;
	public int		staminaMax;

	public int GetValue(EStats stat)
	{
		switch (stat)
		{
		case EStats.STATS_ATTACK :
			return (attack);
		case EStats.STATS_DEFENSE :
			return (defense);
		case EStats.STATS_INITIATIVE :
			return (initiative);
		case EStats.STATS_HEALTH_MAX :
			return (healthMax);
		case EStats.STATS_STAMINA_MAX:
			return (staminaMax);
		default :
			return (-1);
		}
	}
}

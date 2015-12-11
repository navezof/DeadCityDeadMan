using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardManager : MonoBehaviour
{
	private	Character	owner;

    private List<GameObject> guards = new List<GameObject>();

    public List<GameObject> GetGuards() { return (guards); }

	void Start()
	{
		owner = GetComponent<Character>();
	}

    public void AddGuard(GameObject guardPrefab)
    {
		Guard	newGuard;

		print ("Added new guard : " + guardPrefab.name);
		if ((newGuard = guardPrefab.GetComponent<Guard>()) == null)
			return ;
		newGuard.DrawEffect(owner.transform.position);
        guards.Add(guardPrefab);
    }

    public void RemoveGuard(GameObject guardPrefab)
    {
        guards.Remove(guardPrefab);
    }

	public void ClearGuard()
	{
		guards.Clear();
	}

    public int FindGuardOfType(Guard.EType type)
    {
        foreach (GameObject g in guards)
        {
            if (g.GetComponent<Guard>().type == type)
                return (g.GetComponent<Guard>().power);
        }
        return (0);
    }
}
using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour
{
	public Skill[]		knownSkills;
	public Skill[]		equippedSkills;

	public GameObject[]	GO_knowSkills;

	public void ChangeSkill(int newSkill, int oldSkill)
	{
		Skill tmpSkill;

		print ("changing : " + equippedSkills[oldSkill] + " with " + knownSkills[newSkill]);

		if (IsExisting(knownSkills[newSkill]))
			return ;
		tmpSkill = equippedSkills[oldSkill];
		equippedSkills[oldSkill] = knownSkills[newSkill];
		knownSkills[newSkill] = tmpSkill;
	}

	bool IsExisting(Skill skill)
	{
		print ("testing if " + skill.name + " is already equipped");

		foreach (Skill s in equippedSkills)
		{
			if (s == skill)
			{
				print ("s : " + s.name + " == " + skill);
				return (true);
			}
		}
		return (false);
	}
}

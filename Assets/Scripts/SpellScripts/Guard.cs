using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour
{
	public enum EType
	{
		DMG_BOOST,
        HEAL_BOOST
	}

	public int			power;
	public EType		type;
	public GameObject	textPrefab;

	public void DrawEffect(Vector3 textPosition)
	{
		FloatingTextManager.textManager.CreateText(("+ " + power + " " + type), Color.red, textPrefab, textPosition);
	}
}

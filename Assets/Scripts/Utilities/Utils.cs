using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	static public float convertFromPercent(float percent, float max)
	{
		return ((percent * max) / 100);
	}
}

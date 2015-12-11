using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
	public static GameUI	gameUI;
	
	public GameObject	selected;
	public int			specToChange;
	public int			skillToChange;

	public bool			bWaiting;

	void Awake()
	{
		if (gameUI != null)
			Destroy(gameUI);
		else
			gameUI = this;
	}
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void OnGUI()
	{
	}
}

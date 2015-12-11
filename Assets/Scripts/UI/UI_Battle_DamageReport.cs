using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Battle_DamageReport : UI_Base
{
    public SpellEffect_Base     spell;
    private Character           defender;
	private string				defenderName;

	private List<string> reports = new List<string>();

    private string totalValue;
    private string firstValue;
    private string secondValue;
    private string thirdValue;

    public float next_x_p;
    public float next_y_p;
    public float next_w_p;
    public float next_h_p;

    public float cancel_x_p;
    public float cancel_y_p;
    public float cancel_w_p;
    public float cancel_h_p;

    public float detail_x_p;
    public float detail_y_p;
    public float detail_w_p;
    public float detail_h_p;

    public float report_x_p;
    public float report_y_p;
    public float report_y_interval_p;

    private Rect next;
    private Rect cancel;
    private Rect detail;

    private float report_x;
    private float report_y;
    private float report_y_interval;

    private bool bDetails;

	public void SetDefender(Character newDefender) { defenderName = newDefender.name; }

	void Start()
	{
		bDetails = true;
	}

    // Update is called once per frame
    void Update()
    {
        Position();
        PositionChild();
    }

    void PositionChild()
    {
        detail.x = Utils.convertFromPercent(detail_x_p, Screen.width);
        detail.y = Utils.convertFromPercent(detail_y_p, Screen.height);
        detail.width = Utils.convertFromPercent(detail_w_p, Screen.width);
        detail.height = Utils.convertFromPercent(detail_h_p, Screen.height);

        report_x = Utils.convertFromPercent(report_x_p, Screen.width);// +detail.x;
        report_y = Utils.convertFromPercent(report_y_p, Screen.height);// +detail.y;
        report_y_interval = Utils.convertFromPercent(report_y_interval_p, Screen.height);// +detail.y;

        next.x = Utils.convertFromPercent(next_x_p, Screen.width) + rect_position.x;
        next.y = Utils.convertFromPercent(next_y_p, Screen.height) + rect_position.y;
        next.width = Utils.convertFromPercent(next_w_p, Screen.width);
        next.height = Utils.convertFromPercent(next_h_p, Screen.height);

        cancel.x = Utils.convertFromPercent(cancel_x_p, Screen.width) + rect_position.x;
        cancel.y = Utils.convertFromPercent(cancel_y_p, Screen.height) + rect_position.y;
        cancel.width = Utils.convertFromPercent(cancel_w_p, Screen.width);
        cancel.height = Utils.convertFromPercent(cancel_h_p, Screen.height);
    }

    void OnGUI()
    {
        if (skin != null)
            GUI.skin = skin;
        GUI.depth = -1;

        GUI.Box(rect_position, "");
        //GUI.Label(new Rect(report_x, report_y, rect_position.width, rect_position.height), defender.name);

        //if (GUI.Button(next, "Details"))
        //   bDetails = !bDetails;
        if (GUI.Button(cancel, "X"))
        {
            CloseUI();
			reports.Clear();
            //bDetails = false;
        }
        //if (bDetails)
            DrawDetails();
    }

    void DrawDetails()
    {
        float y;

		y = report_y + report_y_interval;
		foreach (string s in reports)
		{
			y += report_y_interval;
			GUI.Label(new Rect(report_x, y, rect_position.width, rect_position.height), defenderName + s);
		}
    }

	public void AddDetails(string newReport)
	{
		reports.Add(newReport);
	}

	public override void CloseUI()
	{
		print ("clear reprt");
		reports.Clear();
		this.enabled = false;
		bIsOpen = true;
	}
}

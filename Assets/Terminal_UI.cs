using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal_UI : UI_Handler
{
    public GameObject terminalPreset;
    public float spacing = 1;
    public int maxCmds = 5;
    public string textDefault = "C:/Sample_Text>";
    
    public Vector3 offsetTopRight = new Vector3(-36.43f, 32.33f, 0f);
    private RectTransform originCmd;
    public HistoryNode head;

    private int header = 0;//i think this name works?


    public void Start()
    {
        LoadTerm();

    }

    public void LoadTerm()
    {
        head = new HistoryNode(terminalPreset, this.gameObject);
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
        Add();
       

    }


    public void Add()
    {
        HistoryNode temp = new HistoryNode(terminalPreset, this.gameObject, head);
        head = temp.AppendTo(temp);
    }


    public void FocusTerminal()
    {

    }
}

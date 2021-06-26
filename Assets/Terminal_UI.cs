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
    public GameObject[] cmds;

    public void Start()
    {
        originCmd = this.GetComponent<RectTransform>();
        LoadTerm();
        
    }

    public void LoadTerm()
    {

        cmds = new GameObject[maxCmds];
        Vector3 topLeft = new Vector3(0, originCmd.rect.y,0) + originCmd.transform.position;
        Debug.Log("topLeftVector" + topLeft);
        for (int iter = 0; iter < maxCmds; iter++ )
        {

            cmds[iter] = Instantiate(terminalPreset, Vector3.up* (float)iter * spacing, this.transform.rotation);
            cmds[iter].GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, originCmd.rect.width);
            cmds[iter].GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, (float)iter * spacing-105, originCmd.rect.height);
            cmds[iter].GetComponent<Text>().text = textDefault;
            cmds[iter].transform.parent = this.transform;
           
        }
    }

    public void FocusTerminal()
    {

    }
}

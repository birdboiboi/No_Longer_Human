using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal_Script : MonoBehaviour
{
    public string text = "C/Sample_Text>";
    public Transform start_Loc;
    public float spacing= 1;
    public GameObject linePrefab;
    public GameObject[] cmds = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
       /* int iter = 0;
        foreach(GameObject cmd in cmds)
        {

            GameObject textBox = Instantiate(linePrefab,this.transform + (float)iter* spacing);
            textBox.parent = this;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

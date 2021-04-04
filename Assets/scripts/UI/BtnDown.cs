using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnDown : MonoBehaviour
{
    public string btnCmd;
    private Button thisBtn;
    void Start()
    {

        thisBtn = this.GetComponent<Button>();
        thisBtn.onClick.AddListener(Press);
    }
    void Press()
    {
        Debug.Log(transform.parent);
        transform.parent.SendMessage(btnCmd);
    }
}

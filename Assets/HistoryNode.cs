using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryNode
{
    private HistoryNode next;
    private string payload;
    private float payloadHight;
    private float timestamp;

    private GameObject unityObject;
    private GameObject unityParent;
    private GameObject thisObject;

    private float defaultLineHeight;
    public string defaultDir = "C/User/Sample>";



    //use this on after frist instance
   public HistoryNode(GameObject unityObject, GameObject unityParent,HistoryNode prev)
    {
        this.timestamp = Time.time;
        this.unityObject = unityObject;
        this.unityParent = unityParent;
        this.payloadHight = this.unityObject.GetComponent<RectTransform>().rect.height + prev.payloadHight;
        this.makeUnityObject(unityObject, unityParent, prev.payloadHight);

        this.incHeight(defaultLineHeight);
    }

    //use this on first instance
    public HistoryNode(GameObject unityObject, GameObject unityParent)
    {
        Debug.Log("new node created"+ unityObject+"and"+ unityParent);
        this.unityObject = unityObject;
        this.unityParent = unityParent;
        this.payloadHight = this.unityObject.GetComponent<RectTransform>().rect.height ;
        this.makeUnityObject(unityObject, unityParent, 0);

        this.incHeight(defaultLineHeight);
    }


    public void makeUnityObject(GameObject terminalPreset, GameObject unityParent,float spacing)
    {
        Debug.Log("creatingUI");
        RectTransform originCmd = unityParent.GetComponent<RectTransform>();
        //this.thisObject = GameObject.Instantiate(terminalPreset, Vector3.up * (float)iter * spacing, unityParent.transform.rotation);
        this.thisObject = GameObject.Instantiate(terminalPreset, Vector3.up * (spacing - 0), unityParent.transform.rotation);
        this.thisObject.transform.parent = unityParent.transform;
        this.thisObject.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, -50, originCmd.rect.width);
        //this.thisObject.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, (float)iter * spacing - 105, originCmd.rect.height);
        this.thisObject.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,  spacing - 0, originCmd.rect.height);
        this.thisObject.GetComponent<Text>().text = defaultDir;
        this.thisObject.transform.SetParent(unityParent.transform);
        Debug.Log("thisObject"+thisObject);
    }

    public string GetMessage()
    {
        return payload;
    }

    public float GetTotalHeight()
    {
        return payloadHight;
    }

    public HistoryNode Next()
    {
        return next;
    }

    public void incHeight(float factor)
    {
         payloadHight+= factor;
    }
   

    public void SetNext(HistoryNode next)
    {
        this.next = next;
    }

    public HistoryNode AppendTo(HistoryNode currHead)
    {
        this.SetNext(currHead.Next());
        currHead.SetNext(this);
        return this;
    }
    
}

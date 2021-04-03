using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterHandler : MonoBehaviour
{
    public Canvas can;
    public GameObject[] letters;
    private GameObject letter;
    //public bool viewThis = false;
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Display(int i)
    {
        letter = Instantiate(letters[i], can.transform);
        letter.transform.SetParent(transform.parent);

    }
    void CloseDisplay()
    {
        Destroy(letter);
    }
}

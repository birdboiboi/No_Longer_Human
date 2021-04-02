using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;

public class PlayTestMusicOnRedCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        JSAM.AudioManager.PlaySound(Sounds.NewAudioFileObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

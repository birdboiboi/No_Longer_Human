using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : ScriptableObject
{

    public MirrorDI[] listOfMirrors;
    public AudioClip ambientAudio;

    private bool playerIn;
    public int eventState;

    // Start is called before the first frame update
    //Assign Mirror's Room object to this Room script for pub-sub capabilities(I think????)
    void Start()
    {
        foreach (MirrorDI mirrorToLinkToRoom in listOfMirrors)
        {
            mirrorToLinkToRoom.thisRoom = this;
        }
    }

    //TODO: Update SaveData
    public void updateSaveData()
    {

    }

    //TODO: generate save data object based on this house instance and and return it as a SaveData type(whatever that is?)
    public SaveData generateSaveData()
    {

    }

    //TODO: implement music starting for external player to call
    private void startAmbientMusic()
    {

    }

    //TODO: implement music ending for external player to call
    private void endAmbientMusic()
    {

    }

    //return list of all mirrors assigned to this room to external player
    //also lets this script know that the player has entered
    public MirrorDI[] getMirrorListOnEnterHouse()
    {
        
        startAmbientMusic();
        playerIn = true;
        updateSaveData();
        return listOfMirrors;
    }

    //also lets this script know that the player has exited
    public void onExitHouse()
    {
        endAmbientMusic();
        playerIn = false;
        updateSaveData();
    }

}

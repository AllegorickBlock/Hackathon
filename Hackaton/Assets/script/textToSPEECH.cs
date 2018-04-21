using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib; //DLL ajoutée

public class textToSPEECH : MonoBehaviour
{
    public SpVoice voice = new SpVoice();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            voice.Speak(InterfaceManager.phraseToSay.text);
            InterfaceManager.phraseToSay.text = "";
        }
    }
}
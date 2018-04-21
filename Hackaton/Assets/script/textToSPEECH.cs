using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class textToSPEECH : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ButtonPress();
        }
    }

    public void ButtonPress()
    {
        SpVoice voice;
        voice = new SpVoice();
        voice.Speak(InterfaceManager.phraseToSay.text);
        InterfaceManager.phraseToSay.text = "";
    }
}
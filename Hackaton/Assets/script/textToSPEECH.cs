using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class textToSPEECH : MonoBehaviour
{
    public UnityEngine.UI.Text texto;

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
        texto.text = InterfaceManager.phraseToSay.text;
        voice.Speak(texto.text);
        InterfaceManager.phraseToSay.text = "";
    }
}
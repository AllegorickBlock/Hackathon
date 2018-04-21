using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;

using UnityEngine.Windows.Speech;

public class textToSPEECH : MonoBehaviour
{
    public UnityEngine.UI.Text texto;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPress();
        }

    }

    public void ButtonPress()
    {
        SpVoice voice;
        voice = new SpVoice();
        voice.Speak("salut");
        voice.Speak(texto.text);

    }


}


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;


public class Client : MonoBehaviour {

    public GameObject chatContainer;
    public GameObject messagePrefab;
    static public bool socketReady;
    static public TcpClient socket;
    static public NetworkStream stream;
    static public StreamReader reader;
    static public StreamWriter writer;
    static public SpVoice voice = new SpVoice(); // Permet d'instancier une voix d'utilisation d'interfac

    public void OnConnectedToServer()
    {
        //si déjà co ignore cette methode

        if (socketReady)
        {
            return;
        }
        string host = "127.0.0.1";
        int port = 6321;

        string h;
        int p;
        h = GameObject.Find("HostInput").GetComponent<InputField>().text;
        if (h != "")
        { 
            host = h;
        }
        int.TryParse(GameObject.Find("PortInput").GetComponent<InputField>().text,out p);
        if (p != 0)
        {
            port = p;
        }
        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
        }
        catch (Exception ex)
        {
            Debug.Log("Socket error :" + ex.Message);
        }
    }

    private void Update()
    {
        if (socketReady)
        {
            
            if (stream.DataAvailable) // Permet d'appuyer sur enter pour envoyer une donnée
            {
                string data = reader.ReadLine();
                if (data != null)
                {
                    OnIncomingData(data);
                    voice.Speak(data, SpeechVoiceSpeakFlags.SVSFlagsAsync); // Rajout permettant decouter ce qui nous est envoyé, le flag en deuxiemme partie permet de jouer le son de maniere asynchrone, et empechant ainsi de bloquer tout le code
                }
            }
        }
    }
    int indice = 0;
    private void OnIncomingData(string data)
    {
        AnimationWithSpeak.peutParler = true;
        AnimationWithSpeak.indice = 0;
        AnimationWithSpeak.textAParler = data;
        GameObject go = Instantiate(messagePrefab, chatContainer.transform)as GameObject;
        
        /*if(indice > 9)*/Destroy(go, 10);
        //else indice++;

        go.GetComponentInChildren<Text>().text = data;
       
    }
    static private void Send(string data)
    {
        if (!socketReady)
        {
            return;
        }
        writer.WriteLine(data);
        writer.Flush();
    }

    static public void OnSendButton()
    {
        if (GameObject.Find("SendInput").GetComponent<InputField>().text != string.Empty)
        {
            string message = GameObject.Find("SendInput").GetComponent<InputField>().text;
            Send(message);
        }
        GameObject.Find("SendInput").GetComponent<InputField>().text = string.Empty;
    }


}

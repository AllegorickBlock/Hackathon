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
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamReader reader;
    private StreamWriter writer;
    public SpVoice voice = new SpVoice(); // Permet d'instancier une voix d'utilisation d'interfac

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
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if (data != null)
                    OnIncomingData(data);
            }
        }
    }

    private void OnIncomingData(string data)
    {
       GameObject go = Instantiate(messagePrefab, chatContainer.transform)as GameObject;
        go.GetComponentInChildren<Text>().text = data;
        voice.Speak(data); // Rajout permettant decouter ce qui nous est envoyé
    }

    private void Send(string data)
    {
        if (!socketReady)
        {
            return;
        }
        writer.WriteLine(data);
        writer.Flush();
    }

    public void OnSendButton()
    {
        string message = GameObject.Find("SendInput").GetComponent<InputField>().text;
        Send(message);
    }
}

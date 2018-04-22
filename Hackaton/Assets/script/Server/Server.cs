using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Collections.Generic;
using System;
using System.Net;
using System.IO;

public class Server : MonoBehaviour 
{
        private List<ServerClient> clients;
        private List<ServerClient> disconnectList;

    public int port = 6321;
    private TcpListener server;
    private bool serverStarted;

    private void Start()
    {
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true;
            Debug.Log("Le server démarre sur le port : "+port.ToString());
        }
        catch (Exception ex)
        {
            Debug.Log("Socket error:" +ex.Message);
        }
    }

    public void SendMessageButton()
    {
        Client.OnSendButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Client.OnSendButton();
        }

        if (!serverStarted)
            return;

        foreach (ServerClient c in clients)
        {
            //Check si le client est co
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null)
                    {
                        OnIncomingData(c, data);
                    }
                }
            }
        }
    }
    private bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null  /*c.Client.Connect*/)
            {
                if(c.Client.Poll(0, SelectMode.SelectRead))
                  {
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                    
                  }
                  return true;
            }
            else
                    return false;
        }
        catch
        {
           return false;
        }
    }
    private void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }
    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;

        clients.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
        StartListening();

        Broadcast(clients[clients.Count-1]+" s'est connecté sur le serveur",clients); 
    }

    private void OnIncomingData(ServerClient c,string data)
    {
        Broadcast(data, clients);
    }
    private void Broadcast(string data, List<ServerClient> cl)
    {
        foreach (ServerClient c in cl)
        { 
            try
            {
                StreamWriter writer = new StreamWriter(c.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }
            catch (Exception ex)
            {
                Debug.Log("Write error :" + ex.Message + "to client" + c.clientName);
            }
        }
    }
    

}



public class ServerClient
{
    public TcpClient tcp;
    public string clientName;

    public ServerClient(TcpClient clientSocket)
    {
        clientName = "Paul";
        tcp = clientSocket;
    }
}


using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using UnityEngine.UI;
public class response : MonoBehaviour
{
    public InputField inputField;

    void Start()
    {
        UDPTest();
    }
    void Update()
    {
        
    }
    void UDPTest()
    {
        UdpClient client = new UdpClient(5600);
        try
        {
            client.Connect("127.0.0.1", 5500);
            byte[] sendBytes = Encoding.ASCII.GetBytes("Hello, from the client");
            client.Send(sendBytes, sendBytes.Length); 

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 5500); 
            byte[] receiveBytes = client.Receive(ref remoteEndPoint);
            string receivedString = Encoding.ASCII.GetString(receiveBytes); 
            print("Message received from the server \n " + receivedString);
        }
        catch (Exception e)
        {
            print("Exception thrown " + e.Message);
        }
    }
}
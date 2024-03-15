using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class LoginData
{
    public string input;
}
public class web : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SendRequest());
    }

    private IEnumerator SendRequest()
    {
        var loginUrl = "http://localhost:3000/login";
        var loginData = new LoginData();
        loginData.input = input;
        var json = JsonUtility.ToJson(loginData);

        using UnityWebRequest webRequest = new UnityWebRequest(loginUrl, "POST");
        webRequest.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
        byte[] rawJson = System.Text.Encoding.UTF8.GetBytes(json);
        webRequest.uploadHandler = new UploadHandlerRaw(rawJson);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("In Progress...");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(webRequest.downloadHandler.text);
                break;
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("Connection Error...");
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("Protocol Error...");
                break;
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("Data Processing Error...");
                break;
            default:
                Debug.Log("Default...");
                break;
        }
    }
}

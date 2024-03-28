using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

// [Serializable]
// public class LoginData
// {
//     public string input;
// }
public class web : MonoBehaviour
{
    public string baseUrl = "http://localhost:3000/";
    public string registerUrl = "http://localhost:3000/register";
    public string loginUrl = "http://localhost:3000/login";
    public TextMeshProUGUI logText;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI passwordText;

    void Start()
    {
        StartCoroutine(GetRequest(baseUrl));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error:\n " + webRequest.error);
                    textChange("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error:\n " + webRequest.error);
                    textChange("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received:\n " + webRequest.downloadHandler.text);
                    textChange("Baglanti Basarili");
                    break;
            }
        }
    }
    void textChange(string statustext)
    {
        logText.text = statustext;
    }
    public void Login()
    {
        if (!string.IsNullOrWhiteSpace(usernameText.text))
        {
            if (!string.IsNullOrWhiteSpace(passwordText.text))
            {
                string auth = $"{{ \"username\": \"{usernameText.text}\", \"password\": \"{passwordText.text}\" }}";

                StartCoroutine(LoginEmu(auth));
            }
            else
            {
                textChange("password boş");
            }
        }
        else
        {
            textChange("username boş");
        }
    }
    IEnumerator LoginEmu(string auth)
    {
        using (UnityWebRequest login = UnityWebRequest.Post(loginUrl, auth, "application/json"))
        {
            yield return login.SendWebRequest();

            if (login.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(login.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            switch (login.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error:\n " + login.error);
                    textChange("Error: " + login.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error:\n " + login.error);
                    textChange("HTTP Error: " + login.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received:\n " + login.downloadHandler.text);
                    textChange("Login Basarili");
                    break;
            }
        }
    }
    public void Register()
    {
        if (usernameText.text.Trim() != "")
        {
            if (passwordText.text.Trim() != "")
            {
                string auth = $"{{ \"username\": \"{usernameText.text}\", \"password\": \"{passwordText.text}\" }}";
                StartCoroutine(RegisterEmu(auth));
            }
            else
            {
                textChange("password boş");
            }
        }
        else
        {
            textChange("username boş");
        }

    }
    IEnumerator RegisterEmu(string auth)
    {
        using (UnityWebRequest register = UnityWebRequest.Post(registerUrl, auth, "application/json"))
        {
            yield return register.SendWebRequest();

            if (register.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(register.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            switch (register.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error:\n " + register.error);
                    textChange("Error: " + register.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error:\n " + register.error);
                    textChange("HTTP Error: " + register.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received:\n " + register.downloadHandler.text);
                    textChange("Register Basarili");
                    break;
            }
        }
    }
}

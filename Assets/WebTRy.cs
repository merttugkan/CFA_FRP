using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTRy : MonoBehaviour
{
    public string webpage;

    public void Test()
    {
        StartCoroutine(Test(""));
    }

    public void Login() 
    {
        StartCoroutine(Login("Tugkan", "123456"));
    }

    public void Register() 
    {
        StartCoroutine(Register("Tugkan", "123456"));
    }

    public string testUri = "";
    public string loginUri = "";
    public string registerUri = "";

    IEnumerator Test(string a)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(testUri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("error");
                Debug.Log(webRequest.error);
            }
            webRequest.Dispose();
        }
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(loginUri,form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("error");
                Debug.Log(webRequest.error);
            }
            webRequest.Dispose();
        }
    }

    IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(registerUri,form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("error");
                Debug.Log(webRequest.error);
            }
            webRequest.Dispose();
        }

    }
}

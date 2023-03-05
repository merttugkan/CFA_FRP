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

    public string testUri = "http://cfafrp.rf.gd/Test.php";
    public string loginUri = "http://cfafrp.rf.gd/Login.php";
    public string registerUri = "http://cfafrp.rf.gd/Register.php";

    //public string testUri = "http://localhost/Test.php";
    //public string loginUri = "http://localhost/Login.php";
    //public string registerUri = "http://localhost/Register.php";

    IEnumerator Test(string a)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(testUri))
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

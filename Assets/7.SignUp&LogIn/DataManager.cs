using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class DataManager : MonoBehaviour {
   
    public static DataManager instance = null;

    private string postLogInUrl = "http://localhost:3000/api/v1/sessions -d";
    private string postSignUpUrl = "http://localhost:3000/api/v1/registrations -d";
    private string deleteLogOutUrl = "http://localhost:3000/api/v1/sessions?auth_token=P-7Cfs15_EyCm-hGYkUe";

    private void Awake()
    {
        instance = null;
    }

    public void PostLogIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", "8");
        form.AddField("password", "brian8");

        WWW www = new WWW(postLogInUrl, form);

        StartCoroutine(WaitForRequest(www));
    }

    public void PostSignUp(SignUpInform signUpInform)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", signUpInform.emailAddr);
        form.AddField("name", signUpInform.name);
        form.AddField("password", signUpInform.password);
        form.AddField("password_confirmation", signUpInform.rePassword);

        WWW www = new WWW(postLogInUrl, form);

        StartCoroutine(WaitForRequest(www));
    }

    //private void OnButtonClicked()
    //{
    //    if (Type == EType.GET)
    //    {
    //        // GET
    //        string url = "http://127.0.0.1:3000/method_get_test/users";
    //        WWW www = new WWW(url);
    //        StartCoroutine(WaitForRequest(www));
    //    }
    //    else if (Type == EType.POST)
    //    {
    //        // POST
    //        string url = "http://127.0.0.1:3000/method_post_test/user";
    //        WWWForm form = new WWWForm();
    //        form.AddField("id", "8");
    //        form.AddField("name", "brian8");
    //        WWW www = new WWW(url, form);

    //        StartCoroutine(WaitForRequest(www));
    //    }
    //    else if (Type == EType.PUT)
    //    {
    //        // PUT
    //        string url = "http://127.0.0.1:3000/method_put_test/user/id/8/ddddd";
    //        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    //        httpWebRequest.ContentType = "text/json";
    //        httpWebRequest.Method = "PUT";

    //        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    //        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
    //        {
    //            string responseText = streamReader.ReadToEnd();
    //            //Now you have your response.
    //            //or false depending on information in the response
    //            Debug.Log(responseText);
    //        }
    //    }
    //    else if (Type == EType.DELETE)
    //    {
    //        // DELETE
    //        string url = "http://127.0.0.1:3000/method_del_test/user/id/8";
    //        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    //        httpWebRequest.ContentType = "text/json";
    //        httpWebRequest.Method = "DELETE";

    //        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    //        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
    //        {
    //            string responseText = streamReader.ReadToEnd();
    //            //Now you have your response.
    //            //or false depending on information in the response
    //            Debug.Log(responseText);
    //        }
    //    }
    //}

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);
            ReceiveData(www.text);
        }
        else
        {
            Debug.Log("WWW error: " + www.error);   // something wrong!
        }
    }

    private void ReceiveData(string receiveData)
    {
    }
}

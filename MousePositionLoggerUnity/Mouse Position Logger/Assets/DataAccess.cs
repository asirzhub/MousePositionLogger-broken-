using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class DataAccess : MonoBehaviour
{
    public TextMeshProUGUI getText;
    public TextMeshProUGUI hrText;
    public string url = "https://localhost:44325/MouseData";
    //public string hrUrl = "https://localhost:44325/HRData";
    //public string rrUrl = "https://localhost:44325/HRData";

    public int entryID = 0;
    public float mousX;
    public float mousY;

    public void PostData()
    {
        float mousX = Input.mousePosition.x;
        float mousY = Input.mousePosition.y;


        //users
        string json = "{" +
        "'Entry': '" + entryID + "'," +
        "'mouseX': '" + Input.mousePosition.x + "'," +
        "'mouseY': '" + Input.mousePosition.y + "'}";

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        json = json.Replace("'", "\"");
        //Encode the JSON string into a bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //Now we call a new WWW request
        WWW www = new WWW(url, postData, headers);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest(www));

        //hrData
        string hrjson = "{" +
        "'rawTime': '" + rawTime + "'," +
        "'timestamp': '" + timestamp + "'," +
        "'heartRate': '" + heartrate + "'," +
        "'maxHeartRate': '" + maxHeartrate + "'," +
        "'exertionScore': '" + exertionScore + "'," +
        "'intensity': '" + intensity + "'," +
        "'meanHR': '" + meanHR + "'," +
        "'ibi': '" + ibi + "'," +
        "'userId': '" + userId + "'}";

        Dictionary<string, string> headers2 = new Dictionary<string, string>();
        headers2.Add("Content-Type", "application/json");

        hrjson = hrjson.Replace("'", "\"");
        //Encode the JSON string into a bytes
        byte[] postData2 = System.Text.Encoding.UTF8.GetBytes(hrjson);
        //Now we call a new WWW request
        WWW www2 = new WWW(hrUrl, postData2, headers2);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest2(www2));
        entryID += 1;
    }

    public void GetData()
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
        WWW www2 = new WWW(hrUrl);
        StartCoroutine(WaitForRequest2(www2));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        getText.text = "loading...";
        yield return www;
        if (www.error == null)
        {
            //Print server response
            getText.text = www.text;
            Debug.Log(www.text);
        }
        else
        {
            getText.text = www.error;
            Debug.Log(www.error);
        }
    }
    IEnumerator WaitForRequest2(WWW www)
    {
        hrText.text = "loading...";
        yield return www;
        if (www.error == null)
        {
            //Print server response
            hrText.text = www.text;
            Debug.Log(www.text);
        }
        else
        {
            hrText.text = www.error;
            Debug.Log(www.error);
        }
    }
}

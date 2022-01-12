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
    public string url = "https://localhost:44325/MouseData";

    public string rawTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff");
    public float mousePositionX;
    public float mousePositionY;

    private void Update()
    {
        mousePositionX = Input.mousePosition.x;
        mousePositionY = Input.mousePosition.y;
    }

    //public int userId = 0;
    //public string rawTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff");
    //public double timestamp = 0;
    //public int heartrate = 99;
    //public int maxHeartrate = 52;
    //public int exertionScore = 2;
    //public string intensity = "low";
    //public double meanHR = 52.0215;
    //public double ibi = 2.021;
   
    public void PostData()
    {
        
        //users
        string json = "{" +
        "'rawtime': '" + rawTime + "'," +
        "'mousePositionX': '" + mousePositionX + "'," +
        "'mousePositionY': '" + mousePositionY + "'}";

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        json = json.Replace("'", "\"");
        //Encode the JSON string into a bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //Now we call a new WWW request
        WWW www = new WWW(url, postData, headers);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest(www));
       
    }

    public void GetData()
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
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
}

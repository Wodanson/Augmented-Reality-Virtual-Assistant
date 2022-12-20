using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;
    //private const string rasa_url = "http://localhost:5005/webhooks/rest/webhook";
    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    List<Message> MessageList = new List<Message>();



    void Start()
    {
        
    }
    void Update()
    {
        if (chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the spacebar");
                Debug.Log("Space");
            }
        }
    }
     
    public void SendMessageToChat(string text)
    {
        if (MessageList.Count >= maxMessages)
        {
            Destroy(MessageList[0].textObject.gameObject);
            MessageList.Remove(MessageList[0]);
        }
        
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        MessageList.Add(newMessage);
    }
    //public void SendMessageToRasa(string text)
    //{
    //    // Create a json object from user message
    //    PostMessageJson postMessage = new PostMessageJson
    //    {
    //        sender = "user",
    //        message = text
    //    };

    //    string jsonBody = JsonUtility.ToJson(postMessage);
    //    print("User json : " + jsonBody);

    //    // Create a post request with the data to send to Rasa server
    //    StartCoroutine(PostRequest(rasa_url, jsonBody));
    //}

    //private IEnumerator PostRequest(string url, string jsonBody)
    //{
    //    UnityWebRequest request = new UnityWebRequest(url, "POST");
    //    byte[] rawBody = new System.Text.UTF8Encoding().GetBytes(jsonBody);
    //    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(rawBody);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    yield return request.SendWebRequest();

    //    Debug.Log("Response: " + request.downloadHandler.text);
    //}
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}

public class PostMessageJson
{
    public string message;
    public string sender;
}
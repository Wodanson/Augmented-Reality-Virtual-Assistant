using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public TouchScreenKeyboard Keyboard;
    public string text = "";

    [SerializeField]
    List<Message> MessageList = new List<Message>();



    void Start()
    {
        
    }
    void Update()
    {
        if ( Keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            SendMessageToChat("test");
            if (chatBox.text != "")
            {
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
        if (chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat("you pressed the space Key");
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
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}

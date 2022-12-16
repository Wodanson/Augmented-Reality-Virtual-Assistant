using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;

    [SerializeField]
    List<Message> MessageList = new List<Message>();

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SendMessageToChat("you pressed the space Key");
            Debug.Log("Space");
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
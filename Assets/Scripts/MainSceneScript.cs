using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using Photon.Chat.Demo;

public class MainSceneScript : MonoBehaviourPunCallbacks
{

    [SerializeField]
    List<string> messageList;

    [SerializeField]
    Text messageText;

    [SerializeField]
    InputField inputMessage;

    public GameObject chatUI;
    
    int countChat = 0;
    

    PhotonView _pv;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        chatUI.transform.position = new Vector3(chatUI.transform.position.x + 250f, chatUI.transform.position.y, 0f);

        if (PhotonNetwork.CurrentRoom == null)
        {
            if (RoleScript.identityNo == 0)
            {
                SceneManager.LoadScene("TeacherMenuScene");
            }
            else
            {
                SceneManager.LoadScene("StudentMenuScene");
            }
            
        } else
        {
            InitClassRoom();
        }
    }

    public void InitClassRoom()
    {
        /*
         * 角色的位置
         */
        Vector3[] spawnPos = new Vector3[] {
            new Vector3(-0.01f,0.135f, 4.02f),
            new Vector3(-2.9f, 0.135f, -4.14f),
            new Vector3(-2.9f, 0.135f,-2.4f),
            new Vector3(-2.9f, 0.135f, -1.03f),
            new Vector3(-2.9f, 0.135f, 0.33f),
            new Vector3(-2.9f, 0.135f, 1.69f),
            new Vector3(-1.033f, 0.135f, -3.77f),
            new Vector3(-1.033f, 0.135f, -2.4f),
            new Vector3(-1.033f, 0.135f, -1.03f),
            new Vector3(-1.033f, 0.135f, 0.33f),
            new Vector3(-1.033f, 0.135f, 1.69f),
            new Vector3(0.82f, 0.135f, -3.77f),
            new Vector3(0.82f, 0.135f, -2.4f),
            new Vector3(0.82f, 0.135f, -1.03f),
            new Vector3(0.82f, 0.135f, 0.33f),
            new Vector3(0.82f, 0.135f, 1.69f),
            new Vector3(2.7f, 0.135f, -3.77f),
            new Vector3(2.7f, 0.135f, -2.4f),
            new Vector3(2.7f, 0.135f, -1.03f),
            new Vector3(2.7f, 0.135f, 0.33f),
            new Vector3(2.7f, 0.135f, 1.69f)
        };

        float spawnPointX = spawnPos[RoleScript.seatNo].x;
        float spawnPointY = spawnPos[RoleScript.seatNo].y;
        float spawnPointZ = spawnPos[RoleScript.seatNo].z;
        string roleName = "";

        /**
         * 生成角色物件
         */
        if(RoleScript.identityNo == 0)
        {
            switch (RoleScript.roleNo)
            {
                case 0:
                    roleName = "Male1";
                    break;
                case 1:
                    roleName = "Male2";
                    break;
                case 2:
                    roleName = "Female";
                    break;
            }
            PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), new Quaternion(0f, 180f, 0f, 0f));
            PhotonNetwork.Instantiate("PPT", new Vector3(-2.25f, 1.64f, 4.94f), new Quaternion(0f, 180f, 0f, 0f));
        }
        else
        {
            switch (RoleScript.roleNo)
            {
                case 0:
                    roleName = "Aj";
                    break;
                case 1:
                    roleName = "Amy";
                    break;
                case 2:
                    roleName = "CoolGirl";
                    break;
            }
            PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), Quaternion.identity);
        }
    }

    public void OnClickSendMessage()
    {
        string message = GetMessage();
        CallRpcSendMessageToAll(message);
    }

    public string GetMessage()
    {
        string message = inputMessage.text;
        return message.Trim();
    }

    /*
     * 聊天視窗
     */
    [PunRPC]
    void RpcSendMessage(string message, PhotonMessageInfo info)
    {
        if(messageList.Count >= 20)
        {
            messageList.RemoveAt(0);
        }
        message = $"{info.Sender.NickName}:{message}";
        messageList.Add(message);
        UpdateMessage();
    }

    void UpdateMessage()
    {
        messageText.text = string.Join("\n", messageList);
    }

    public void CallRpcSendMessageToAll(string message)
    {
        _pv.RPC("RpcSendMessage", RpcTarget.All, message);
    }

    public void OnClickChatButton()
    {
        if (countChat % 2 == 0)
        {
            chatUI.transform.position = new Vector3(chatUI.transform.position.x - 250f, chatUI.transform.position.y, 0f);
            countChat++;
        }
        else
        {
            chatUI.transform.position = new Vector3(chatUI.transform.position.x + 250f, chatUI.transform.position.y, 0f);
            countChat++;
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MainSceneScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    List<string> messageList;

    [SerializeField]
    Text messageText;

    [SerializeField]
    InputField inputMessage;

    PhotonView _pv;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();

        if(PhotonNetwork.CurrentRoom == null)
        {
            SceneManager.LoadScene("MenuScene");
        } else
        {
            // 初始化
            InitClassRoom();
        }

    }

    public void InitClassRoom()
    {
        // 隨機生成角色的位置
        Vector3[] spawnPos = new Vector3[] {
            new Vector3(-0.01f,0.135f, 4.02f),
            new Vector3(-2.9f, 0.135f, -3.8f),
            new Vector3(-2.9f, 0.135f,-2.06f),
            new Vector3(-2.9f, 0.135f, -0.69f),
            new Vector3(-2.9f, 0.135f, 0.67f),
            new Vector3(-2.9f, 0.135f, 2.03f),
            new Vector3(-1.033f, 0.135f, -3.43f),
            new Vector3(-1.033f, 0.135f, -2.06f),
            new Vector3(-1.033f, 0.135f, -0.69f),
            new Vector3(-1.033f, 0.135f, 0.67f),
            new Vector3(-1.033f, 0.135f, 2.03f),
            new Vector3(0.82f, 0.135f, -3.43f),
            new Vector3(0.82f, 0.135f, -2.06f),
            new Vector3(0.82f, 0.135f, -0.69f),
            new Vector3(0.82f, 0.1351f, 0.67f),
            new Vector3(0.82f, 0.135f, 2.03f),
            new Vector3(2.7f, 0.135f, -3.4f),
            new Vector3(2.7f, 0.135f, -2.06f),
            new Vector3(2.7f, 0.135f, -0.69f),
            new Vector3(2.7f, 0.135f, 0.67f),
            new Vector3(2.7f, 0.135f, 2.03f)
    };

        float spawnPointX = spawnPos[RoleScript.seatNo].x;
        float spawnPointY = spawnPos[RoleScript.seatNo].y;
        float spawnPointZ = spawnPos[RoleScript.seatNo].z;
        string roleName = "";

        if (RoleScript.roleNo == 0)
        {
            roleName = "Aj";
            // 生成角色物件
            PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), Quaternion.identity);
        } else if (RoleScript.roleNo == 1)
        {
            roleName = "Ch46_nonPBR";
            // 生成角色物件
            PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), Quaternion.identity);
        }
        else if (RoleScript.roleNo == 2)
        {
            roleName = "Ch23_nonPBR";
            // 生成角色物件
            PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), new Quaternion(0f, 180f, 0f, 0f));
            PhotonNetwork.Instantiate("PPT", new Vector3(-2.25f, 1.64f, 4.94f), new Quaternion(0f, 180f, 0f, 0f));

        }
    }

    public string GetMessage()
    {
        string message = inputMessage.text;
        return message.Trim(); // Trim可以過濾掉空白字元
    }

    public void OnClickSendMessage()
    {
        string message = GetMessage();
        CallRpcSendMessageToAll(message);
    }

    public void CallRpcSendMessageToAll(string message)
    {
        _pv.RPC("RpcSendMessage", RpcTarget.All, message);
    }

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
}

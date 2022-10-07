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
        float spawnPointX = Random.Range(-3, 3);
        float spawnPointY = 0;
        float spawnPointZ = 0;
        string roleName = "";

        switch (RoleScript.roleNo)
        {
            case 0:
                roleName = "Aj";
                break;
            case 1:
                roleName = "Aj";
                break;
            default:
                roleName = "Aj";
                break;
        }
        // 生成角色物件
        PhotonNetwork.Instantiate(roleName, new Vector3(spawnPointX, spawnPointY, spawnPointZ), Quaternion.identity);

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
        message = $"{_pv.Owner.NickName}:{message}";
        messageList.Add(message);
        UpdateMessage();
    }

    void UpdateMessage()
    {
        messageText.text = string.Join("\n", messageList);
    }
}

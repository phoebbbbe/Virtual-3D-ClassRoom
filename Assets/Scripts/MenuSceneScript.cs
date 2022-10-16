using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MenuSceneScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField inputRoomName;

    [SerializeField]
    InputField inputSeatNumber;

    [SerializeField]
    InputField inputPlayerName;

    [SerializeField]
    Text textRoomList;

    void Start()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("StartScene");
        }
        else {
            if (PhotonNetwork.CurrentLobby == null)
            {
                PhotonNetwork.JoinLobby();
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master.");
        PhotonNetwork.JoinLobby();
    }

    /*
     * 進入Lobby後
     */
    public override void OnJoinedLobby()
    {
        print("Joined Lobby.");

    }

    public string GetRoomName()
    {
        string roomName = inputRoomName.text;
        return roomName.Trim();
    }

    public string GetPlayerName()
    {
        string playerName = inputPlayerName.text;
        return playerName.Trim();
    }

    /*
     * 創建教室
     */
    public void OnClickCreateRoom()
    {
        string roomName = GetRoomName();
        string playerName = GetPlayerName();

        if (roomName.Length > 0 && playerName.Length > 0)
        {
            PhotonNetwork.CreateRoom(roomName);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            if (RoleScript.identityNo == 0)
            {
                RoleScript.seatNo = 0;
            }
            else
            {
                RoleScript.seatNo = int.Parse(inputSeatNumber.text);
            }
        } else
        {
            print("Invalid RoomName or PlayerName!");
        }

    }

    public override void OnJoinedRoom()
    {
        print("Room Joined!");
        SceneManager.LoadScene("RoomScene");
    }

    /*
     * 進入教室
     */
    public void OnClickEnterRoom()
    {
        string roomName = GetRoomName();
        string playerName = GetPlayerName();
        if (roomName.Length > 0 && playerName.Length > 0)
        {
            PhotonNetwork.JoinRoom(roomName);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            RoleScript.seatNo = int.Parse(inputSeatNumber.text);
        } else
        {
            print("Invalid RoomName!");
        }
    }

    /*
     * 顯示遊戲列表(每次遊戲列表有更新時，觸發此函式，則會收到roomList房間資訊)
     */
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.PlayerCount > 0)
            {
                sb.AppendLine(">>" + roomInfo.Name + roomInfo.PlayerCount);
            }
        }
        textRoomList.text = sb.ToString();
        print(int.Parse(inputSeatNumber.text));
    }
    
}

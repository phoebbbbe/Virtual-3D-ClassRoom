using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviourPunCallbacks
{
    public void OnClickStart()
    {
        // 連線進伺服器
        PhotonNetwork.AutomaticallySyncScene = true; // 打開自動同步場景
        PhotonNetwork.ConnectUsingSettings();
        print("Click Start");
    }

    public override void OnConnectedToMaster()
    {
        print("Connected");
        SceneManager.LoadScene("RoleScene");
    }
}

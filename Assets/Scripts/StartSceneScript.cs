using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviourPunCallbacks
{
    /*
     * 連線進伺服器
     */
    public void OnClickStart()
    {
        // 打開自動同步場景
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();

        print("Click Start");
    }

    /*
     * 連線進伺服器後
     */
    public override void OnConnectedToMaster()
    {
        print("Connected");

        // 切換至選擇身份頁面
        SceneManager.LoadScene("IdentityScene");
    }
}

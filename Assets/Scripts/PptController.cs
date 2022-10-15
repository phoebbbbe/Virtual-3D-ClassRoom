using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using HashTable = ExitGames.Client.Photon.Hashtable;


public class PptController : MonoBehaviourPunCallbacks
{
    private PhotonView _pv;
    public Material[] materials;
    int pptCount;
    Renderer rend;

    /*
     * 初始化PPT
     */
    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        pptCount = 0;
        rend = this.gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[pptCount];
    }

    public void OnChanged(int x)
    {
        rend.sharedMaterial = materials[x];
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, HashTable changedProps)
    {
        if (targetPlayer == _pv.Owner)
        {
            pptCount = (int)changedProps["pptCount"];
            OnChanged(pptCount);
        }
    }

    //public void NextPpt()
    //{
    //    if (x < 13)
    //    {
    //        x++;
    //    }
    //    else
    //    {
    //        x = 0;
    //    }
    //}

    //public void LastPpt()
    //{
    //    if (x >= 0)
    //    {
    //        x--;
    //    }
    //    else
    //    {
    //        x = 0;
    //    }
    //}
}
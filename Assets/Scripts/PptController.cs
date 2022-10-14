using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Photon.Pun;

public class PptController : MonoBehaviour
{
    public Material[] materials;
    public int x;
    Renderer rend;

    //public GameObject buttonNextPpt;
    //public GameObject buttonLastPpt;

    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[x];

        //buttonNextPpt.SetActive(PhotonNetwork.IsMasterClient);
        //buttonLastPpt.SetActive(PhotonNetwork.IsMasterClient);
    }

    void Update()
    {
        rend.sharedMaterial = materials[x];
    }

    public void NextPpt()
    {
        if (x < 13)
        {
            x++;
        }
        else
        {
            x = 0;
        }
    }

    public void LastPpt()
    {
        if (x >= 0)
        {
            x--;
        }
        else
        {
            x = 0;
        }
    }
}
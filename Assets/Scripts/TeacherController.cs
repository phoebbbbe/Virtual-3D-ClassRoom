using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class TeacherController : MonoBehaviourPunCallbacks
{
    public TextMesh nametext;
    private PhotonView _pv;
    private Animator animator;
    int isGesturingHash;
    int isWavingHash;
    int pptCount;

    [SerializeField]
    GameObject buttonNextPpt;

    [SerializeField]
    GameObject buttonLastPpt;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        isGesturingHash = Animator.StringToHash("isGesturing");
        isWavingHash = Animator.StringToHash("isWaving");
        nametext.text = _pv.Owner.NickName;
        pptCount = 0;

        buttonNextPpt.SetActive(PhotonNetwork.IsMasterClient);
        buttonLastPpt.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        buttonNextPpt.SetActive(PhotonNetwork.IsMasterClient);
        buttonLastPpt.SetActive(PhotonNetwork.IsMasterClient);
    }

    void Update()
    {
        if (_pv.IsMine)
        {
            Gesture();
            Wave();
        }
    }

    void Gesture()
    {
        bool isGesturing = animator.GetBool(isGesturingHash);
        bool gesturePressed = Input.GetKey(KeyCode.C);
        if (!isGesturing && gesturePressed)
        {
            animator.SetBool(isGesturingHash, true);
        }
        if (isGesturing && !gesturePressed)
        {
            animator.SetBool(isGesturingHash, false);
        }
    }

    void Wave()
    {
        bool isWaving = animator.GetBool(isWavingHash);
        bool wavePressed = Input.GetKey(KeyCode.A);
        if (!isWaving && wavePressed)
        {
            animator.SetBool(isWavingHash, true);
        }
        if (isWaving && !wavePressed)
        {
            animator.SetBool(isWavingHash, false);
        }
    }

    public void NextPpt()
    {
        if (_pv.IsMine)
        {
            HashTable table = new HashTable();
            if (pptCount < 13)
            {
                pptCount++;
            }
            else
            {
                pptCount = 0;
            }
            table.Add("pptCount", pptCount);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
        }
    }

    public void LastPpt()
    {
        if (_pv.IsMine)
        {
            HashTable table = new HashTable();
            if (pptCount >= 0)
            {
                pptCount--;
            }
            else
            {
                pptCount = 0;
            }
            table.Add("pptCount", pptCount);
            PhotonNetwork.LocalPlayer.SetCustomProperties(table);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, HashTable changedProps)
    {
        
    }
}

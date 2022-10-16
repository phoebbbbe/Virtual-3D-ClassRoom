using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using HashTable = ExitGames.Client.Photon.Hashtable;
using System.Text;

public class TeacherController : MonoBehaviourPunCallbacks
{
    public TextMesh nametext;
    private PhotonView _pv;
    private Animator animator;
    public GameObject textStudentCountObj;
    public GameObject titleStudentCountObj;
    int isGesturingHash;
    int isWavingHash;
    int pptCount;

    [SerializeField]
    GameObject buttonNextPpt;

    [SerializeField]
    GameObject buttonLastPpt;

    [SerializeField]
    Text textStudentCount;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        isGesturingHash = Animator.StringToHash("isGesturing");
        isWavingHash = Animator.StringToHash("isWaving");
        nametext.text = _pv.Owner.NickName;
        pptCount = 0;

        if (PhotonNetwork.CurrentRoom.PlayerCount <= 1)
        {
            textStudentCount.text = "0";
        }
        else
        {
            textStudentCount.text = (PhotonNetwork.CurrentRoom.PlayerCount - 1).ToString();
        }
        
        buttonNextPpt.SetActive(PhotonNetwork.IsMasterClient);
        buttonLastPpt.SetActive(PhotonNetwork.IsMasterClient);
        textStudentCountObj.SetActive(PhotonNetwork.IsMasterClient);
        titleStudentCountObj.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        textStudentCountObj.SetActive(PhotonNetwork.IsMasterClient);
        titleStudentCountObj.SetActive(PhotonNetwork.IsMasterClient);
        buttonNextPpt.SetActive(PhotonNetwork.IsMasterClient);
        buttonLastPpt.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void UpdatePlayerList()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount <= 1)
        {
            textStudentCount.text = "0";
        }
        else
        {
            textStudentCount.text = (PhotonNetwork.CurrentRoom.PlayerCount - 1).ToString();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
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
        bool gesturePressed = Input.GetKey(KeyCode.G);
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
        bool wavePressed = Input.GetKey(KeyCode.W);
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

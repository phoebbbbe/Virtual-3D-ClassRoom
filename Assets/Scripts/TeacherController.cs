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
    public GameObject buttonGesture;
    public GameObject buttonWave;
    public GameObject buttonExplain;
    public GameObject explainUI;
    int isGesturingHash;
    int isWavingHash;
    int pptCount;
    int countExplain = 0;

    [SerializeField]
    GameObject buttonNextPpt;

    [SerializeField]
    GameObject buttonLastPpt;

    [SerializeField]
    Text textStudentCount;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        nametext.text = _pv.Owner.NickName;

        animator = this.gameObject.GetComponent<Animator>();
        isGesturingHash = Animator.StringToHash("isGesturing");
        isWavingHash = Animator.StringToHash("isWaving");
        pptCount = 0;

        if (PhotonNetwork.CurrentRoom.PlayerCount <= 1)
        {
            textStudentCount.text = "0";
        }
        else
        {
            textStudentCount.text = (PhotonNetwork.CurrentRoom.PlayerCount - 1).ToString();
        }
        
        buttonNextPpt.SetActive(_pv.IsMine);
        buttonLastPpt.SetActive(_pv.IsMine);
        textStudentCountObj.SetActive(_pv.IsMine);
        titleStudentCountObj.SetActive(_pv.IsMine);
        buttonGesture.SetActive(_pv.IsMine);
        buttonWave.SetActive(_pv.IsMine);
        buttonExplain.SetActive(_pv.IsMine);
        explainUI.SetActive(_pv.IsMine);
        explainUI.transform.position = new Vector3(explainUI.transform.position.x - 250f, explainUI.transform.position.y, 0f);
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
        buttonNextPpt.SetActive(_pv.IsMine);
        buttonLastPpt.SetActive(_pv.IsMine);
        textStudentCountObj.SetActive(_pv.IsMine);
        titleStudentCountObj.SetActive(_pv.IsMine);
        buttonGesture.SetActive(_pv.IsMine);
        buttonWave.SetActive(_pv.IsMine);
        if (_pv.IsMine)
        {
            InitAnimation();
        }
    }

    public void Gesture()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isGesturingHash, true);

        }
    }

    public void Wave()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isWavingHash, true);

        }
    }


    public void InitAnimation()
    {
        if (animator.GetBool(isGesturingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Arm Gesture") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isGesturingHash, false);
        }

        if (animator.GetBool(isWavingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Waving") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isWavingHash, false);
        }
    }
    public void NextPpt()
    {
        if (_pv.IsMine)
        {
            HashTable table = new HashTable();
            if (pptCount < 25)
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

    public void OnClickExplainButton()
    {
        if (_pv.IsMine)
        {
            if (countExplain % 2 == 0)
            {
                explainUI.transform.position = new Vector3(explainUI.transform.position.x + 250f, explainUI.transform.position.y, 0f);
                countExplain++;
            }
            else
            {
                explainUI.transform.position = new Vector3(explainUI.transform.position.x - 250f, explainUI.transform.position.y, 0f);
                countExplain++;
            }
        }

    }

}

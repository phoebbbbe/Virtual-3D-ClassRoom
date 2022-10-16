using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using HashTable = ExitGames.Client.Photon.Hashtable;
using System.Text;

public class StudentController : MonoBehaviourPunCallbacks
{
    public TextMesh nametext;
    private PhotonView _pv;
    private Animator animator;
    public GameObject buttonAsk;
    public GameObject buttonBang;
    public GameObject buttonClap;
    public GameObject buttonLook;
    public GameObject buttonPump;
    public GameObject buttonStandClap;
    public GameObject buttonTalk;
    public GameObject buttonTumb;
    public GameObject buttonVictory;
    public GameObject buttonWave;
    int isClappingHash;
    int isAskingHash;
    int isTumbingHash;
    int isBangingHash;
    int isPumppingHash;
    int isTalkingHash;
    int isLookingHash;
    int isStandClappingHash;
    int isVictoringHash;
    int isWavingHash;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        nametext.text = _pv.Owner.NickName;

        animator = this.gameObject.GetComponent<Animator>();
        isClappingHash = Animator.StringToHash("isClapping");
        isAskingHash = Animator.StringToHash("isAsking");
        isTumbingHash = Animator.StringToHash("isTumbing");
        isBangingHash = Animator.StringToHash("isBanging");
        isPumppingHash = Animator.StringToHash("isPumpping");
        isTalkingHash = Animator.StringToHash("isTalking");
        isLookingHash = Animator.StringToHash("isLooking");
        isStandClappingHash = Animator.StringToHash("isStandClapping");
        isVictoringHash = Animator.StringToHash("isVictoring");
        isWavingHash = Animator.StringToHash("isWaving");

        buttonAsk.SetActive(_pv.IsMine);
        buttonBang.SetActive(_pv.IsMine);
        buttonClap.SetActive(_pv.IsMine);
        buttonLook.SetActive(_pv.IsMine);
        buttonPump.SetActive(_pv.IsMine);
        buttonStandClap.SetActive(_pv.IsMine);
        buttonTalk.SetActive(_pv.IsMine);
        buttonTumb.SetActive(_pv.IsMine);
        buttonVictory.SetActive(_pv.IsMine);
        buttonWave.SetActive(_pv.IsMine);

    }

    void Update()
    {
        buttonAsk.SetActive(_pv.IsMine);
        buttonBang.SetActive(_pv.IsMine);
        buttonClap.SetActive(_pv.IsMine);
        buttonLook.SetActive(_pv.IsMine);
        buttonPump.SetActive(_pv.IsMine);
        buttonStandClap.SetActive(_pv.IsMine);
        buttonTalk.SetActive(_pv.IsMine);
        buttonTumb.SetActive(_pv.IsMine);
        buttonVictory.SetActive(_pv.IsMine);
        buttonWave.SetActive(_pv.IsMine);
        if (_pv.IsMine)
        {
            InitAnimation();
        }
    }

    public void Clap()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isClappingHash, true);
        }
    }

    public void Ask()
    {
        animator.SetBool(isAskingHash, true);
    }

    public void Tumb()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isTumbingHash, true);

        }
    }

    public void Bang()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isBangingHash, true);

        }
    }

    public void Pump()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isPumppingHash, true);

        }
    }

    public void Talk()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isTalkingHash, true);

        }
    }

    public void Look()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isLookingHash, true);

        }
    }

    public void StandClap()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isStandClappingHash, true);

        }
    }

    public void Victory()
    {
        if (_pv.IsMine)
        {
            animator.SetBool(isVictoringHash, true);

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
        if (animator.GetBool(isAskingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Asking Question") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isAskingHash, false);
        }

        if (animator.GetBool(isBangingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Banging Fist") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isBangingHash, false);
        }

        if (animator.GetBool(isClappingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Clapping") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isClappingHash, false);
        }

        if (animator.GetBool(isTumbingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Sitting Thumbs Up") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isTumbingHash, false);
        }

        if (animator.GetBool(isTalkingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Sitting Talking") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isTalkingHash, false);
        }

        if (animator.GetBool(isPumppingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Sitting Fist Pump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isPumppingHash, false);
        }

        if (animator.GetBool(isLookingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Sitting") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isLookingHash, false);
        }

        if (animator.GetBool(isStandClappingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Standing Clap") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isStandClappingHash, false);
        }

        if (animator.GetBool(isVictoringHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Victory") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isVictoringHash, false);
        }

        if (animator.GetBool(isWavingHash) == true && animator.GetCurrentAnimatorStateInfo(0).IsName("Waving") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            animator.SetBool(isWavingHash, false);
        }
    }

}

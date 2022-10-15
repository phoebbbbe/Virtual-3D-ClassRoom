using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using HashTable = ExitGames.Client.Photon.Hashtable;


public class StudentController : MonoBehaviourPunCallbacks
{
    public TextMesh nametext;
    private PhotonView _pv;
    private Animator animator;
    int isClappingHash;
    int isAskingHash;
    int isTumbingHash;
    int isBangingHash;
    int isPumpingHash;
    int isTalkingHash;
    int isLookingHash;
    int isStandClappingHash;
    int isVictoringHash;
    int isWavingHash;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        isClappingHash = Animator.StringToHash("isClapping");
        isAskingHash = Animator.StringToHash("isAsking");
        isTumbingHash = Animator.StringToHash("isTumbing");
        isBangingHash = Animator.StringToHash("isBanging");
        isPumpingHash = Animator.StringToHash("isPumping");
        isTalkingHash = Animator.StringToHash("isTalking");
        isLookingHash = Animator.StringToHash("isLooking");
        isStandClappingHash = Animator.StringToHash("isStandClapping");
        isVictoringHash = Animator.StringToHash("isVictoring");
        isWavingHash = Animator.StringToHash("isWaving");

        nametext.text = _pv.Owner.NickName;
    }

    void Update()
    {
        if (_pv.IsMine)
        {
            Clap();
            Ask();
            Tumb();
            Bang();
            Pump();
            Talk();
            Look();
            StandClap();
            Victory();
            Wave();
        }
    }

    void Clap()
    {
        bool isClapping = animator.GetBool(isClappingHash);
        bool clapPressed = Input.GetKey(KeyCode.C);
        if (!isClapping && clapPressed)
        {
            animator.SetBool(isClappingHash, true);
        }
        if (isClapping && !clapPressed)
        {
            animator.SetBool(isClappingHash, false);
        }
    }

    void Ask()
    {
        bool isAsking = animator.GetBool(isAskingHash);
        bool askPressed = Input.GetKey(KeyCode.A);
        if (!isAsking && askPressed)
        {
            animator.SetBool(isAskingHash, true);
        }
        if (isAsking && !askPressed)
        {
            animator.SetBool(isAskingHash, false);
        }
    }

    void Tumb()
    {
        bool isTumbing = animator.GetBool(isTumbingHash);
        bool tumbPressed = Input.GetKey(KeyCode.T);
        if (!isTumbing && tumbPressed)
        {
            animator.SetBool(isTumbingHash, true);
        }
        if (isTumbing && !tumbPressed)
        {
            animator.SetBool(isTumbingHash, false);
        }
    }

    void Bang()
    {
        bool isBanging = animator.GetBool(isBangingHash);
        bool bangPressed = Input.GetKey(KeyCode.B);
        if (!isBanging && bangPressed)
        {
            animator.SetBool(isBangingHash, true);
        }
        if (isBanging && !bangPressed)
        {
            animator.SetBool(isBangingHash, false);
        }
    }

    void Pump()
    {
        bool isPumping = animator.GetBool(isPumpingHash);
        bool pumpPressed = Input.GetKey(KeyCode.P);
        if (!isPumping && pumpPressed)
        {
            animator.SetBool(isPumpingHash, true);
        }
        if (isPumping && !pumpPressed)
        {
            animator.SetBool(isPumpingHash, false);
        }
    }

    void Talk()
    {
        bool isTalking = animator.GetBool(isTalkingHash);
        bool talkPressed = Input.GetKey(KeyCode.K);
        if (!isTalking && talkPressed)
        {
            animator.SetBool(isTalkingHash, true);
        }
        if (isTalking && !talkPressed)
        {
            animator.SetBool(isTalkingHash, false);
        }
    }

    void Look()
    {
        bool isLooking = animator.GetBool(isLookingHash);
        bool lookPressed = Input.GetKey(KeyCode.L);
        if (!isLooking && lookPressed)
        {
            animator.SetBool(isLookingHash, true);
        }
        if (isLooking && !lookPressed)
        {
            animator.SetBool(isLookingHash, false);
        }
    }

    void StandClap()
    {
        bool isStandClap = animator.GetBool(isStandClappingHash);
        bool standClapPressed = Input.GetKey(KeyCode.S);
        if (!isStandClap && standClapPressed)
        {
            animator.SetBool(isStandClappingHash, true);
        }
        if (isStandClap && !standClapPressed)
        {
            animator.SetBool(isStandClappingHash, false);
        }
    }

    void Victory()
    {
        bool isVictoring = animator.GetBool(isVictoringHash);
        bool victoryPressed = Input.GetKey(KeyCode.V);
        if (!isVictoring && victoryPressed)
        {
            animator.SetBool(isVictoringHash, true);
        }
        if (isVictoring && !victoryPressed)
        {
            animator.SetBool(isVictoringHash, false);
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

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, HashTable changedProps)
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    private PhotonView _pv;    
    Animator animator;
    int isClappingHash,isAskingHash,isTumbingHash;
    public TextMesh nametext;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        isClappingHash = Animator.StringToHash("isClapping");
        isAskingHash = Animator.StringToHash("isAsking");
        isTumbingHash = Animator.StringToHash("isTumbing");
        nametext.text = _pv.Owner.NickName;
    }

    void Update()
    {
        if (_pv.IsMine)
        {
            Clap();
            Ask();
            Tumb();
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
}

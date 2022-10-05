using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    //private Transform _transform;
    private PhotonView _pv;
    //public float speed;
    Animator animator;
    int isWalkingHash;
    int isWavingHash;
    int isSittingHash;
    int isStandingHash;
    int isClappingHash;
    int isAskingHash;

    void Start()
    {
        //_transform = this.transform;
        _pv = this.gameObject.GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWavingHash = Animator.StringToHash("isWaving");
        isSittingHash = Animator.StringToHash("isSitting");
        isStandingHash = Animator.StringToHash("isStanding");
        isClappingHash = Animator.StringToHash("isClapping");
        isAskingHash = Animator.StringToHash("isAsking");

    }

    // Update is called once per frame
    void Update()
    {
        if (_pv.IsMine)
        {
            Control();
        }
    }

    /* 角色控制 */
    void Control()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey(KeyCode.RightArrow);
        bool isWaving = animator.GetBool(isWavingHash);
        bool wavePressed = Input.GetKey(KeyCode.W);
        bool isSitting = animator.GetBool(isSittingHash);
        bool sitPressed = Input.GetKey(KeyCode.DownArrow);
        bool isStanding = animator.GetBool(isStandingHash);
        bool standPressed = Input.GetKey(KeyCode.UpArrow);
        bool isClapping = animator.GetBool(isClappingHash);
        bool clapPressed = Input.GetKey(KeyCode.C);
        bool isAsking = animator.GetBool(isAskingHash);
        bool askPressed = Input.GetKey(KeyCode.A);

        if (!isWalking && forwardPressed) // Walking Right
        {
            //_transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isWaving && wavePressed) // Waving
        {
            animator.SetBool(isWavingHash, true);
        }
        if (isWaving && !wavePressed)
        {
            animator.SetBool(isWavingHash, false);
        }

        if (!isClapping && clapPressed) // Clapping
        {
            //_transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetBool(isClappingHash, true);
        }
        if (isClapping && !clapPressed)
        {
            animator.SetBool(isClappingHash, false);
        }

        if (!isAsking && askPressed) // Asking
        {
            animator.SetBool(isAskingHash, true);
        }
        if (isAsking && !askPressed)
        {
            animator.SetBool(isAskingHash, false);
        }

        if (!isSitting && sitPressed) // Sitting
        {
            animator.SetBool(isSittingHash, true);
            animator.SetBool(isStandingHash, false);

        }

        if (!isStanding && standPressed) // Standing
        {
            animator.SetBool(isStandingHash, true);
            animator.SetBool(isSittingHash, false);

        }


        if (Input.GetKey(KeyCode.LeftArrow)) // Walking Left
        {
            //_transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(!Input.GetKey(KeyCode.LeftArrow))
        {
        }
    }
}

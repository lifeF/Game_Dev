﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    Animator animator;
    InputController PlayerInputController;
    // Use this for initialization
   
	void Awake () {
        animator = GetComponentInChildren<Animator>();
        PlayerInputController = GetComponentInChildren<InputController>();

    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Vertical", PlayerInputController.Vertical);
        animator.SetFloat("Horizontal", PlayerInputController.Horizontal);

        //// Use for transition
        animator.SetBool("IsWalking", PlayerInputController.IsWalking);
        animator.SetBool("IsSprinting", PlayerInputController.IsSprinting);
        animator.SetBool("IsCrouched", PlayerInputController.IsCrouched);

        // up down animation 
        //animator.SetFloat("AimAngle", PlayerAim.GetAngle());
        //// aiming
        //animator.SetBool("IsAiming",
                         // GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING || 
                         //GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING);

    }
}

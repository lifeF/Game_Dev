﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamara : MonoBehaviour {

    [System.Serializable]
    public class CameraRig{
        public Vector3 CameraOffset;
        public float CrouchHeight;
        public float Damping;
    } 

    // 1.25 , 1 , -8
    // 5

    [SerializeField]
    CameraRig defaultCamera;

    [SerializeField]
    CameraRig aimCamera;


    Transform CamaraLookTarget;


    public Player LocalPlayer;
	void Awake () {
        GameManager.Instance.OnLocalPlayerJoin += HandleLocalPlayer;
	}

    private void HandleLocalPlayer(Player player)
    {
        LocalPlayer = player;
        CamaraLookTarget = LocalPlayer.transform.Find("camaraLookTarget");
        if (CamaraLookTarget == null)
            CamaraLookTarget = LocalPlayer.transform;
    }
    
    void Update () {
        if (LocalPlayer == null)
            return;

        CameraRig cameraRig = defaultCamera;

        if (LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING || LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING)
            cameraRig = aimCamera;

        float targetHeight = cameraRig.CameraOffset.y + (LocalPlayer.PlayerState.MoveState == PlayerState.EMoveState.CROUCHING ? cameraRig.CrouchHeight : 0);
        Vector3 targetPosisiton = CamaraLookTarget.transform.position + LocalPlayer.transform.forward * cameraRig.CameraOffset.z+ 
                LocalPlayer.transform.up * targetHeight +
                LocalPlayer.transform.right * cameraRig.CameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(CamaraLookTarget.position - targetPosisiton, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosisiton, cameraRig.Damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.Damping * Time.deltaTime);

    }
}

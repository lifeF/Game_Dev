﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupItem
{

    [SerializeField] EWeaponType weaponType;
    [SerializeField] float respawnTime;
    [SerializeField] int amount;
    public override void OnPickup(Transform item)
    {

        var playerInventory = item.GetComponentInChildren<Container>();
        GameManager.Instance.Respawner.Despawn(gameObject, respawnTime);
        playerInventory.Put(weaponType.ToString(), amount);

        item.GetComponent<PlayerShoot>().ActiveWeapon.reloader.HandleOnAmmoChanged();
    }
}
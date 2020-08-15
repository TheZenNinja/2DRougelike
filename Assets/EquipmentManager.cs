﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    //public WeaponItem[] weapons = new WeaponItem[3];
    public Transform playerHands;
    public Transform playerHandDir;
    public PlayerControl playerControl;
    public EquipmentBase currentItem;
    public EquipmentUI ui;
    public Animator anim;
    private bool flipped { get { return playerControl.flipped; } }

    void Start()
    {
    }

    void Update()
    {
        currentItem.HandleInput();
        ui.UpdateUI(currentItem.GetUIData());

        playerHandDir.eulerAngles = new Vector3(0,0, CursorControl.GetMouseAngle(playerHandDir.position));
        //playerHands.right = flipped ?  -playerControl.mouseDir : playerControl.mouseDir;
        playerHands.localScale = flipped ? new Vector3(-1,1,1) : Vector3.one;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private int _HP = 30;

    protected override void UseItem()
    {
        //HP È¸º¹

        base.UseItem();
    }
}

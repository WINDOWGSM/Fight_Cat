using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private int _hpAmount = 30; //체력 증가량

    protected override void UseItem(PlayerStatus p)
    {
        //HP 회복
        p._hp = _hpAmount;

        base.UseItem(p);
    }
}

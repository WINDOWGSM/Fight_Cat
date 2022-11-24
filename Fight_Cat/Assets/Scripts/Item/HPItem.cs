using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private int _hpAmount = 30; //ü�� ������

    protected override void UseItem(PlayerStatus p)
    {
        //HP ȸ��
        p._hp = _hpAmount;

        base.UseItem(p);
    }
}

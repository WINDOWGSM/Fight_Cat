using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private int _hpAmount = 30; //ü�� ������

    protected override void UseItem(PlayerController p)
    {
        //HP ȸ��
        p.HP = _hpAmount;

        base.UseItem(p);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int _scoreAmount;     //���� ������

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UseItem(PlayerController p)
    {
        //�÷��̾����� ���� ��ŭ ���ϱ�
        p.Score += this._scoreAmount;

        base.UseItem(p);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int _score;     //����

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UseItem()
    {
        //�÷��̾����� ���� ��ŭ ���ϱ�

        base.UseItem();
    }
}

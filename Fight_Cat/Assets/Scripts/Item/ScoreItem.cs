using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    private int _score = 0;     //����

    // Start is called before the first frame update
    void Start()
    {
        _score = Random.Range(10, 21);
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

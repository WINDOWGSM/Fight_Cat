using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    private int _score = 0;     //점수

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
        //플레이어한테 점수 만큼 더하기

        base.UseItem();
    }
}

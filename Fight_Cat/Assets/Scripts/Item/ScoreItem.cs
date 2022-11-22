using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int _score;     //점수

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
        //플레이어한테 점수 만큼 더하기

        base.UseItem();
    }
}

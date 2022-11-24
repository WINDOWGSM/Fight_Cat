using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int _scoreAmount;     //점수 증가량

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UseItem(PlayerStatus p)
    {
        //플레이어한테 점수 만큼 더하기
        p._score += this._scoreAmount;

        base.UseItem(p);
    }
}

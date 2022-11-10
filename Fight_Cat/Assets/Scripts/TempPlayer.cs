using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempPlayer : MonoBehaviour,IPointerClickHandler  
{
    public UserInfo info;

    public void OnPointerClick(PointerEventData eventData)
    {
        RankSystem.Instance.Users.Add(info);
        RankSystem.Instance.SortRank();
    }
}

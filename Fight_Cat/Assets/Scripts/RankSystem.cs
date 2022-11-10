using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    public static RankSystem Instance;

    [SerializeField]
    public List<UserInfo> Users;

    [SerializeField]
    Transform RankPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SortRank()
    {
        Users.Sort((user1, user2) => user1.UserScore.CompareTo(user2.UserScore));
        Users.Reverse();
        foreach(var user in Users)
        {
            Debug.Log($":: UserName : {user.UserName} | UserScore : {user.UserScore}");
        }
        SetUserData();
    }

    public void SetUserData()
    {
        for (int k = 0; k < 10; k++)
        {
            RankPanel.gameObject.transform.GetChild(k).GetComponent<Rank>().rank_user = null;
        }
        
        for(int i = 0; i<Mathf.Clamp(Users.Count,0,10); i++)
        {
            GameObject child = RankPanel.gameObject.transform.GetChild(i).gameObject;
            if(!child.activeSelf)
                child.SetActive(true);
            child.TryGetComponent<Rank>(out Rank rank);
            rank.rank_user = Users[i];
            rank.SetData();
        }
    }
    
}

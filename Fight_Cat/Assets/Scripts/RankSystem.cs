using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    [SerializeField]
    List<UserInfo> Users;

    public void SortRank()
    {
        Users.Sort((user1, user2) => user1.UserScore.CompareTo(user2.UserScore));
        Users.Reverse();
        foreach(var user in Users)
        {
            Debug.Log($":: UserName : {user.UserName} | UserScore : {user.UserScore}");
        }
    }

    
}

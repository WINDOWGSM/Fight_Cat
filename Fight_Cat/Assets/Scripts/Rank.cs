using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField]
    private Text rank_rating;
    [SerializeField]
    private Text rank_name;
    [SerializeField]
    private Text rank_score;

    public UserInfo rank_user;

    private void Awake()
    {
        try
        {
            rank_rating = transform.GetChild(0).GetComponent<Text>();
            rank_name = transform.GetChild(1).GetComponent<Text>();
            rank_score = transform.GetChild(2).GetComponent<Text>();

            rank_rating.text = $"{name}";
            rank_user = null;
            //SetData();
        }
        catch (UnityException e)
        {
            Debug.Log(e.StackTrace);
        }
    }

    private void Update()
    {
        if ((rank_user != null))
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
            rank_score.text = $"{rank_user.UserScore}";
        }
        else
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }

    public void SetData()
    {
        rank_name.text = rank_user.UserName;
        rank_score.text = $"{rank_user.UserScore}";
    }
}

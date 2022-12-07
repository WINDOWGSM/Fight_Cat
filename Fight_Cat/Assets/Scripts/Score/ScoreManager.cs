using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] PlayerController _myPlayer;
    [SerializeField] TMP_Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController[] players = FindObjectsOfType(typeof(PlayerController)) as PlayerController[];

        foreach (PlayerController player in players)
        {
            if (player._PV.IsMine)
            {
                _myPlayer = player;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        _scoreText.text = _myPlayer.Score.ToString();
    }
}

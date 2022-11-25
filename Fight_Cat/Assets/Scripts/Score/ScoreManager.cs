using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] PlayerController _myPlayer;

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
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField _InputField;
    [SerializeField] GameObject connectPanel;
    [SerializeField] GameObject RespawnPanel;


    private void Awake()
    {
        PhotonNetwork.SendRate = 60;        //초당 몇번이나 PhotonNetwork 가 패키지를 전송해야 하는지 정의
        PhotonNetwork.SerializationRate = 30;
    }

    //에디터에서 설정된 Photon 에 연결
    public void Connecting() => PhotonNetwork.ConnectUsingSettings();   

}

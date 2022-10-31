using Photon.Pun;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;


[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    #region private Constants

    TMP_InputField _inputField;
    const string playerNamePrekey = "PlayerName";

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        string defalutName = string.Empty;
        _inputField = this.GetComponent<TMP_InputField>();
        if(_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrekey))
            {
                defalutName = PlayerPrefs.GetString(playerNamePrekey);
                _inputField.text = defalutName;
            }
            //_inputField.onValueChanged.AddListener(delegate { SetPlayerName(_inputField.text); });
        }

        PhotonNetwork.NickName = defalutName;

    }



    #endregion

    #region Public Methods


    public void SetPlayerName()
    {
        if(_inputField.text != "")
        {
            Debug.LogError("NoName");
            return;
        }

        PhotonNetwork.NickName = _inputField.text;
        PlayerPrefs.SetString(playerNamePrekey, _inputField.text);
    }



    #endregion
}

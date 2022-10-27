using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    #region private Constants

    const string playerNamePrekey = "PlayerName";

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        string defalutName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();
        if(_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrekey))
            {
                defalutName = PlayerPrefs.GetString(playerNamePrekey);
                _inputField.text = defalutName;
            }
        }

        PhotonNetwork.NickName = defalutName;

    }

    #endregion

    #region Public Methods


    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(playerNamePrekey, value);
    }

    #endregion
}

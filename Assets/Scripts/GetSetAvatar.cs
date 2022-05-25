using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetAvatar : MonoBehaviour
{
    public InputField _newUsername;
    public Text _mainUsername;
    //public Image _mainAvatar;
    GetPlayerAccountInfo _getPlayerAccountInfo;

   
    private void Awake()
    {
        _getPlayerAccountInfo = new GetPlayerAccountInfo();
        _getPlayerAccountInfo.GetAccountInfo();
        _newUsername.text = _getPlayerAccountInfo._displayName;
        
    }
    public void GetPlayerName()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), 
        
        Result =>
        {
            _mainUsername.text = Result.AccountInfo.TitleInfo.DisplayName;
        
        },
        Error => 
        {
        
        
        
        
        });
    }
    public void SetAvatarUpload(string URL)
    {
      
        URL = URL.ToString();
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {

            ImageUrl = URL

        },
        Result =>
        {

            Debug.Log("Görsel Yuklendi");


        },
        Error =>
        {


            Debug.Log("Görsel Yukleme Basarisiz");


        });
    }
    public void ChangeUsername()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {

            DisplayName = _newUsername.text,

        },
        Result =>
        {
            Debug.Log("Username successfully changed");

        },
        Error =>
        {


            Debug.Log("Username change failed");

        });
    }
}

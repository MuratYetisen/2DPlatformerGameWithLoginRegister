using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using System;

public class GetPlayerAccountInfo 
{
    public string _displayName, _email, _avatarURL, _playfabID;
        public DateTime _createdDate;
    
  public void GetAccountInfo()
    {
        PlayFabClientAPI.GetAccountInfo(new PlayFab.ClientModels.GetAccountInfoRequest(), 
            Result => 
            {

                _displayName = Result.AccountInfo.TitleInfo.DisplayName;
                _email = Result.AccountInfo.PrivateInfo.Email;
                _playfabID = Result.AccountInfo.PlayFabId;
                _createdDate = Result.AccountInfo.TitleInfo.Created.Date;
                _avatarURL = Result.AccountInfo.TitleInfo.AvatarUrl;

            },
            Error => 
            {
            
            
            
            
            });
    }
}

using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetAvatar : MonoBehaviour
{
    [SerializeField] InputField _newUsername;
   
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

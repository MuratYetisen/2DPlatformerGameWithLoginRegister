using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RegisterBase
{
    public bool Register_Async { get; set; }
    public void RegisterControl(InputField _email, InputField _username,InputField _password, InputField _repeatPassword,Button _registerButton)
    {
        if (_email.text.IndexOf('@') < 0 || _email.text.IndexOf('.') < 0 || _password.text != _repeatPassword.text || _password.text.Length < 6 || _username.text.IndexOf('_') > 0)
        {
            _registerButton.interactable = false;

        }
        else
        {
            _registerButton.interactable = true;
        }
        _username.text = Regex.Replace(_username.text, "[^\\w\\._]", "");
        _username.text = Regex.Replace(_username.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");

        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {

            DisplayName = _username.text,
            Email = _email.text,
            Username = _username.text,
            Password = _password.text,


        },
        Result =>
        {

            Debug.Log("Register Successful");
            Register_Async = true;
        },
        Error =>
         {

             Debug.Log("Register Failed");
             Register_Async = false;
         }) ;  
    }
    
}

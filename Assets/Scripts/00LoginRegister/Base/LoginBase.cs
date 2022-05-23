using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LoginBase 
{
    public bool Async_Login { get; set; }
    public void LoginControl(InputField _email,InputField _username,InputField _input,InputField _password,InputField _loginButton)
    {
        if (_email.text.IndexOf('@') < 0 || _email.text.IndexOf('.') < 0 || _password.text.Length < 6 || _username.text.IndexOf('_') > 0)
        {
            _loginButton.interactable = false;

        }
        else
        {
            _loginButton.interactable = true;
        }
        _username.text = Regex.Replace(_username.text, "[^\\w\\._]", "");
        _username.text = Regex.Replace(_username.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");

       
    }
    public void LoginWithEmail(InputField _email,InputField _password)
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest() 
        {
        Email=_email.text,
        Password=_password.text
        }, 
        Result => 
        {

            Debug.Log("Access Successful");
            Async_Login = true;
        },
        Error => 
        {

            Debug.Log("Access Failed");
            Async_Login = false;
        });
    }
    public void LoginWithUsername(InputField _username, InputField _password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = _username.text,
            Password = _password.text
        },
        Result =>
        {

            Debug.Log("Access Successful");
            Async_Login = true;
        },
        Error =>
        {

            Debug.Log("Access Failed");
            Async_Login = false;
        });
    }
}

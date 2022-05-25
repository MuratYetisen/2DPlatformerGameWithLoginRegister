using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _loginPanel, _registerPanel,_asyncPanel;
    [SerializeField] Text _asyncText;
    [SerializeField] InputField _email, _password, _username, _repeatPassword;
    [SerializeField] Button _registerButton;
    [SerializeField] bool _PlayGuest;
    RegisterBase _registerBase;
    private void Awake()
    {
        _registerBase = new RegisterBase();
    }
   public void RegisterOnClick()
    {

        StartCoroutine(RegisterAsyncControl());
    }
    IEnumerator RegisterAsyncControl()
    {
        _asyncPanel.SetActive(true);
        _asyncText.text = "Being Registered";
        _registerBase.RegisterControl(_email, _username, _password, _repeatPassword, _registerButton);
        if (_registerBase.Register_Async == false)
        {
            yield return new WaitForSeconds(1f);
            _asyncPanel.SetActive(false);
            _anim.Play("Failed");
        }
        else
        {
            yield return new WaitUntil(() => _registerBase.Register_Async);
            _asyncText.text = "Register is Successful";
            yield return new WaitForSeconds(1f);
            _asyncPanel.SetActive(false);
            _anim.Play("Success");
        }
        

    }
    public void SwitchLoginOrRegister()
    {
        if (_registerPanel.activeInHierarchy)
        {
            _loginPanel.SetActive(true);
            _registerPanel.SetActive(false);
        }
        else
        {
            _registerPanel.SetActive(true);
            _loginPanel.SetActive(false);
        }

    }
    public void PlayGuestControl()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = _PlayGuest,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier

        }, Result =>
        {
            Debug.Log("Access Successful");
            _anim.Play("Success");
            Invoke("LoadS", 1f);
            
        }, Error =>
        {

            Debug.Log("Access Failed");
            _anim.Play("Failed");
        }) ; 
        
    }
   void LoadS()
    {
        SceneManager.LoadScene(1);
    }
    
}

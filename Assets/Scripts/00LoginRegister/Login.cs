using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _asyncPanel;
    [SerializeField] Text _asyncText;
    [SerializeField] InputField  _password,_input;
    LoginBase _loginBase;
    void Awake()
    {
        _loginBase = new LoginBase();
    }

    void Update()
    {
        
    }

    public void LoginOnClick()
    {
        StartCoroutine(LoginAsyncControl());
    }
    IEnumerator LoginAsyncControl()
    {
        _asyncPanel.SetActive(true);
        _asyncText.text = "Logging in";
        if (_input.text.IndexOf('@') > 0)
        {
            LoginWithEmail();
        }
        else
        {
            LoginWithUsername();
        }
        yield return new WaitUntil(() => _loginBase.Async_Login);
        _asyncText.text = "Logged in";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
        if (_loginBase.Async_Login==false)
        {
            _asyncPanel.SetActive(false);
            _anim.Play("Failed");
        }
       
        
    }
    void LoginWithEmail()
    {
        _loginBase.LoginWithEmail(_input, _password);
        
    }
    void LoginWithUsername()
    {
        _loginBase.LoginWithUsername(_input, _password);
       
    }
}

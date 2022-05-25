using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] GameObject _dashboardPanel,_avatarChangePanel,_usernameChangePanel,_defaultImage,Image4,Image5,Image6,Image7;
    [SerializeField] Text _playerName;
    GetPlayerAccountInfo _getPlayerAccountInfo;
    GetSetAvatar _getSetAvatar;
    void Awake()
    {


        _getPlayerAccountInfo = new GetPlayerAccountInfo();
        _getPlayerAccountInfo.GetAccountInfo();
        _playerName.text = _getPlayerAccountInfo._displayName;
        _getSetAvatar = GetComponent<GetSetAvatar>();

    }
    void Update()
    {

    }
    public void DashboardActivator()
    {
        if (_dashboardPanel.activeInHierarchy==false)
        {
            _dashboardPanel.SetActive(true);
        }
        else
        {
            _dashboardPanel.SetActive(false);
        }
    }
    public void AvatarChangePanelActivator()
    {
        if (_avatarChangePanel.activeInHierarchy)
        {
            _avatarChangePanel.SetActive(false);
        }
        else
        {
            _avatarChangePanel.SetActive(true);
        }
    }
    public void UsernameChangePanelActivator()
    {
        if (_usernameChangePanel.activeInHierarchy)
        {
            _usernameChangePanel.SetActive(false);
        }
        else
        {
            _usernameChangePanel.SetActive(true);
        }
    }
    public void DefaultImageChangerImage4()
    {
        _defaultImage.SetActive(false);
        Image4.SetActive(true);
        Image5.SetActive(false);
        Image6.SetActive(false);
        Image7.SetActive(false);
    }
    public void DefaultImageChangerImage5()
    {
        _defaultImage.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(true);
        Image6.SetActive(false);
        Image7.SetActive(false);
    }
    public void DefaultImageChangerImage6()
    {
        _defaultImage.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);
        Image6.SetActive(true);
        Image7.SetActive(false);
    }
    public void DefaultImageChangerImage7()
    {
        _defaultImage.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);
        Image6.SetActive(false);
        Image7.SetActive(true);
    }
}

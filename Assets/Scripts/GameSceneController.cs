using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] GameObject _dashboardPanel,_avatarChangePanel,_usernameChangePanel;
    [SerializeField] Text _playerName;
    GetPlayerAccountInfo _getPlayerAccountInfo;
    GetSetAvatar _getSetAvatar;
    void Awake()
    {


        _getPlayerAccountInfo = new GetPlayerAccountInfo();
        _getPlayerAccountInfo.GetAccountInfo();
        _playerName.text = _getPlayerAccountInfo._displayName;
        _getSetAvatar = new GetSetAvatar();

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
}

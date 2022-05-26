using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Dash : MonoBehaviour
{
    [SerializeField] GameObject _dashboard;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void DashboardActivator()
    {
        if (_dashboard.activeInHierarchy)
        {
            _dashboard.SetActive(false);
        }
        else
        {
            _dashboard.SetActive(true);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField] GameObject _gameOverImage,_youWinImage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Time.timeScale = 0;
            StartCoroutine(GameOverC());
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
        if (collision.gameObject.tag=="Finish")
        {
            Time.timeScale = 0;
            StartCoroutine(YouWinC());
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }
    IEnumerator GameOverC()
    {
        _gameOverImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        _gameOverImage.SetActive(false);
        
    }
    IEnumerator YouWinC()
    {
        _youWinImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        _youWinImage.SetActive(false);
       
    }
}

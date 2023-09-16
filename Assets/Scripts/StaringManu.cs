using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaringManu : MonoBehaviour
{
    public GameObject getReadyPanel;
    public AudioSource audiosource;
    private void Start()
    {
        Invoke("GetReady", 1f);
        getReadyPanel.SetActive(false);
    }
    void GetReady()
    {
        getReadyPanel.SetActive(true);
        audiosource.Play();
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}

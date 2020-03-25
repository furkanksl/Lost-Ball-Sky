using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    AudioSource sounds;
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        sounds.Play();
        sounds.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openGame()
    {
        SceneManager.LoadScene("GAME");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}


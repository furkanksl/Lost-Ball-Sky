using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    AudioSource sounds;
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        sounds.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene("GAME");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

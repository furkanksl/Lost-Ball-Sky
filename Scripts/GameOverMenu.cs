using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    AudioSource sounds;
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        sounds.Play();

        int gameOverCount = PlayerPrefs.GetInt("gameOverCount");

        if (gameOverCount >= 4)
        {
            GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGoster();
            Debug.Log("GAMEOVERCOUNT="+gameOverCount);
            PlayerPrefs.SetInt("gameOverCount", 0);
            

        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

public class BallControl : MonoBehaviour
{   
    Rigidbody fizik;
    public int speed;
    public int jumpSpeed;
    public int gameOverCount = 0;
    public int scoreCount = 0;
    public Text scoreText;
    public int bestScore = 0;
    public Text bestScoreText;
   

    AudioSource []sounds;

    public float BONUS_GRAV { get; private set; }

    void Start()
    {
        fizik  = GetComponent<Rigidbody>();
        sounds = GetComponents<AudioSource>();

        //PlayerPrefs.DeleteAll();
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreText.text = "Best :" + bestScore;
    }
     void Update()
    {


        float yatay = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;

        //Debug.Log("yatayda=" + yatay);

        if (yatay > 4 || yatay < -4)
        {
            //sounds[2].Play();
            gameOverCount = PlayerPrefs.GetInt("gameOverCount");
            gameOverCount++;
            PlayerPrefs.SetInt("gameOverCount", gameOverCount);

            SceneManager.LoadScene("GameOverMenu");
            
        }
        if (scoreCount > bestScore)
        {
            bestScore = scoreCount;
            PlayerPrefs.SetInt("bestScore", bestScore);
            bestScoreText.text = "Best :" + bestScore;
        }
            


    }

    void FixedUpdate()
    {
        speed = 6;
        float yatay = CrossPlatformInputManager.GetAxisRaw("Horizontal");
     
        float dikey = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(yatay , 0 , dikey);

        fizik.AddForce(vec*speed);

       // float yatayY = ball.transform.position.y;


        

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            fizik.AddForce((new Vector3(0, 3, 0))*jumpSpeed);
            speed = 5;
        }*/
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            

            fizik.AddForce((new Vector3(0, 3, 0)) * jumpSpeed);

            vec = new Vector3(0, 0, 0);
            fizik.AddForce(vec * speed);

            sounds[3].Play();
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    

    void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "baits"){

            scoreCount++;
            scoreText.text = "" + scoreCount;
            other.gameObject.SetActive(false);
            sounds[0].Play();
            //if (scoreCount > bestScore)
            //{
            //    bestScore = scoreCount;
            //    PlayerPrefs.SetInt("bestScore", bestScore);
            //}
        }
        if (other.gameObject.tag == "zafer")
        {
            //sounds[2].Play();
            SceneManager.LoadScene("GameWon");
            
        }
        if (other.gameObject.tag == "danger")
        {
            //sounds[1].Play();
            gameOverCount = PlayerPrefs.GetInt("gameOverCount");
            gameOverCount++;
            PlayerPrefs.SetInt("gameOverCount", gameOverCount);

            SceneManager.LoadScene("GameOverMenu");
            
        }

       

    }
}

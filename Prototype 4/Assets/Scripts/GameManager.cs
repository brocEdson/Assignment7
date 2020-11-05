/* Broc Edson
 * Assignment 7
 * Manages winning and losing and the start of the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text centerText;
    public bool won;
    public bool ended;
    public bool start;

    void Start()
    {
        start = true;
        Time.timeScale = 0;
        centerText.text = "Avoid falling off\nGet past Wave 10 to win\nPress Space to Begin";
    }

    void Update()
    {
        if(start)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                start = false;
                centerText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if(ended)
        {
            Time.timeScale = 0;
            centerText.gameObject.SetActive(true);
            if (won)
            {
                centerText.text = "You Won!\nPress R to Restart";
            }
            else
            {
                centerText.text = "You Lose!\nPress R to Restart";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

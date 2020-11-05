/* Broc Edson
 * Assignment 7
 * Manages the start and end of the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool start = true;
    public bool ended = false;
    public bool won = false;
    public bool scoreGoal = false;

    public Text centerText;

    void Start()
    {
        start = true;
        Time.timeScale = 0;
        centerText.gameObject.SetActive(true);
        centerText.text = "Get to Wave 10 to Win\nYou Lose if all balls in a wave get to your goal\nPress SPACE to Start";
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
            centerText.gameObject.SetActive(true);
            if(won)
            {
                centerText.text = "You Win!\nPress R to Restart";
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

    public void CheckWaveEnd(int wave)
    {
        if(!scoreGoal && !ended && wave != 1)
        {
            ended = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int numLlamas;
    public int numBlocks;
    public int levelNum;
    public Text lives;
    public Text gameover;
    public float goTimer;
    int numLevels;
    public float timeout;

    // Use this for initialization
    void Start () {

        numLlamas = 5;
        lives.text = "Llamas: " + numLlamas;
        gameover.text = "";
        goTimer = 0f;
        timeout = 7f;
        numLevels = 3;

    }
	
	// Update is called once per frame
	void Update () {

        if (numBlocks <= 0)
        {
            if (levelNum == numLevels)
            {
                gameover.text = "You Win!";
                goTimer += Time.deltaTime;

                if (goTimer >= timeout)
                {
                    SceneManager.LoadScene("Title");
                }

            }
            else { 
            SceneManager.LoadScene("Level" + (levelNum + 1));
            //SceneManager.LoadScene("Title");
            }
        }
		
	}
}

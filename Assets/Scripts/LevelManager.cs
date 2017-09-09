using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int numLlamas = 5;
    public int numBlocks;
    public int levelNum;
    public Text lives;
    public Text gameover;
    public float goTimer;

    // Use this for initialization
    void Start () {

        lives.text = "Llamas: " + numLlamas;
        gameover.text = "";
        goTimer = 0f;

    }
	
	// Update is called once per frame
	void Update () {

        if (numBlocks <= 0)
        {
           // SceneManager.LoadScene("Level" + (levelNum + 1));
            SceneManager.LoadScene("Title");
        }
		
	}
}

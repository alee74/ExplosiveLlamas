using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockCollider : MonoBehaviour {

    private LevelManager lvlMan;

	// Use this for initialization
	void Start () {

        lvlMan = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D block)
    {
        lvlMan.numBlocks--;
        Debug.Log(lvlMan.numBlocks);
    }
}

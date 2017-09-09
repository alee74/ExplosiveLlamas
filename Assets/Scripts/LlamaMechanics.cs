using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LlamaMechanics : MonoBehaviour {

    Rigidbody2D llama;
    Camera cam;
    Vector2 slingStart;
    Vector2 slingEnd;
    Vector2 resetPos;
    float forceMultiplier;
    float countdown;
    float timeout;
   
    bool launched;

    public LevelManager lvlMan;



	// Use this for initialization
	void Start () {

        llama = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        forceMultiplier = 500f;
        launched = false;
        timeout = 7f;
        countdown = timeout;
        resetPos = transform.position;

        lvlMan = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (lvlMan.numLlamas <= 0)
        {
            lvlMan.gameover.text = "Game Over";
            lvlMan.goTimer += Time.deltaTime;

            if (lvlMan.goTimer >= timeout)
            {
                SceneManager.LoadScene("Title");
            }

        } else {

            if (launched)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    LlamaReset();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                slingStart = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0) && !launched)
            {
                slingEnd = cam.ScreenToWorldPoint(Input.mousePosition);
                //Debug.Log(slingEnd);
                llama.AddForce((slingStart - slingEnd) * forceMultiplier);
                launched = true;
                countdown = timeout;
            }
        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            LlamaReset();
        }
    }

    void LlamaReset()
    {
        transform.position = resetPos;
        llama.velocity = Vector2.zero;
        llama.angularVelocity = 0f;
        transform.rotation = Quaternion.identity;
        launched = false;
        lvlMan.numLlamas--;
        lvlMan.lives.text = "Llamas: " + lvlMan.numLlamas;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GamepadInput;

public class sceneManger : MonoBehaviour {

    Scene currentScene;    
    string previousScene;
    public string titleSceneName;
    public string singlePlayerSceneName;
    public string multiPlayerSceneName;
    public string gameOverSceneName;

    // Use this for initialization
    void Start () {
        Object.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        currentScene = SceneManager.GetActiveScene();

        //quits
        if (GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.One))
        {
            Application.Quit(); 
        }

        if (string.Equals(currentScene.name, "title"))
        {
            titleScene();
        }

        else if (string.Equals(currentScene.name, "arenaSingle"))
        {
            singleScene();
        }

        else if (string.Equals(currentScene.name, "arenaMulti"))
        {
            mulltiScene();
        }

        else if (string.Equals(currentScene.name, "gameOver"))
        {
            gameOverScene();
        }
    }

    void titleScene() 
    {
        string selection = ContentsManager.getSelection().name;

        if (string.Equals(selection,"play") && GamePad.GetButtonDown(GamePad.Button.A,GamePad.Index.One))
        {
            SceneManager.LoadScene(singlePlayerSceneName);
        }
        else if (string.Equals(selection, "quit") && GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One))
        {
            Application.Quit();
        }
    }

    void singleScene()
    {
        previousScene = singlePlayerSceneName;

        if (Input.GetKeyDown(KeyCode.M))//player is dead
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    void mulltiScene()
    {
        previousScene = multiPlayerSceneName;

        if (Input.GetKeyDown(KeyCode.M))//player wins
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    void gameOverScene() {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(previousScene);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(titleSceneName);
        }
    }
}

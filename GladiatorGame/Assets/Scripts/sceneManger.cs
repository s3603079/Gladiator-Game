using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManger : SingletonMonoBehaviour<sceneManger>
{
    Scene currentScene;
    string previousScene;
    public Object thisObject;
    public string titleSceneName;
    public string singlePlayerSceneName;
    public string multiPlayerSceneName;
    public string gameOverSceneName;

    protected override void Awake() {
        base.Awake();
    }

    // Use this for initialization
    void Start()
    {
        //Object.DontDestroyOnLoad(thisObject);
    }

    // Update is called once per frame
    void Update()
    {

#if true
        currentScene = SceneManager.GetActiveScene();

        //quits
        if (Input.GetKeyDown(KeyCode.Escape))
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
#endif
    }

    void titleScene()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(singlePlayerSceneName);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(multiPlayerSceneName);
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

    void gameOverScene()
    {

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

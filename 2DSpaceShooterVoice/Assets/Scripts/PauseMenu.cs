using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Grammer Recogniser script which deals with loading the pause menu by saying pause and resuming the game by saying resume
 */

public class PauseMenu : MonoBehaviour
{
    //Variables
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GrammarRecognizer gr;
    private string _outAction;

    void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "pauseMenuGrammar.xml"), ConfidenceLevel.Low);
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammar loaded and recogniser started!");

    }

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        //Phase recognizer
        StringBuilder message = new StringBuilder();
        Debug.Log("Recognised a phrase");

        // read the semantic meanings from the args passed in.
        SemanticMeaning[] meanings = args.semanticMeanings;

        // semantic meanings are returned as key/value pairs
        // use foreach to get all the meanings.
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
            message.Append("Key: " + keyString + ", Value: " + valueString + " ");
            _outAction = valueString;

            switch (_outAction)
            {
                case "resume":
                    Resume();
                    break;
                case "pause":
                    Pause();
                    break;
                case "quit":
                    QuitGame();
                    break;
            }
        }
        // use a string builder to create the string and out put to the user
        Debug.Log(message);
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (gameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }
    //}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("LoadMenu");
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
        Application.Quit();
    }
}

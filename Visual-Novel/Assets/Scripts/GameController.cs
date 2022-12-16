using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public SpeechController speechController;

    // Start is called before the first frame update
    void Start()
    {
        speechController.PlayScene(currentScene);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (speechController.isCompleted())
            {
                speechController.PlayNextSentence();
            }
        }
    }
}

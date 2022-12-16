using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechController : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI speakerText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        speakerText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        speakerText.color = currentScene.sentences[sentenceIndex].speaker.textColor; 
    }

    public bool isCompleted()
    {
        return state == State.COMPLETED;
    }

    public IEnumerator TypeText(string text)
    {
        bodyText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            bodyText.text += text[wordIndex];
            yield return new WaitForSeconds(0.03f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}

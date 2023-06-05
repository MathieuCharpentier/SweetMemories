using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPlayer : MonoBehaviour
{
    TextMeshProUGUI uiText;
    public GameObject dialogueBox;
    public string Sentence;
    string textToWrite;
    int characterIndex;
    public float timePerCharacter;
    private float timer;
    public bool invisibleCharacters;
    public static bool working = false;

    public void AddWriter()
    {
        if(working)
        {
            StopAllCoroutines();
        }

        uiText = dialogueBox.GetComponent<TextMeshProUGUI>();
        textToWrite = Sentence;
        characterIndex = 0;
        working = true;
    }

    private void Update()
    {
        if(uiText != null)
        {
            dialogueBox.SetActive(true);
            timer -= Time.deltaTime;
            while(timer <= 0f)
            {
                if(characterIndex != textToWrite.Length)
                {
                    timer += timePerCharacter;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacters)
                    {
                        text += "<color=#000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text;
                }

                if(characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    StartCoroutine("DisableBox");
                    return;
                }
            }
        }
    }

    IEnumerator DisableBox()
    {
        yield return new WaitForSeconds(3f);
        working = false;
        dialogueBox.SetActive(false);
        this.gameObject.GetComponent<TextPlayer>().enabled = false;
    }
}

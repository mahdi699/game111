using System.Collections;
using TMPro;
using UnityEngine;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continuebutton;
    void Start()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continuebutton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    public void Nextsentence()
    {
        continuebutton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
        }
    }
}


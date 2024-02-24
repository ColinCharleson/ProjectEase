using UnityEngine;
using TMPro;
using System.Collections;

public class VologramSwitch : MonoBehaviour
{
    public GameObject idleVologram;
    public GameObject talkingVologram;
    public TextMeshProUGUI textComponent;
    public GameObject panel;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // Call this method when you want to switch to the talking vologram
    public void SwitchToTalking()
    {
        idleVologram.SetActive(false);
        talkingVologram.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
        panel.SetActive(true);
    }

    // Call this method when you want to switch back to the idle vologram
    public void SwitchToIdle()
    {
        talkingVologram.SetActive(false);
        idleVologram.SetActive(true);
        panel.SetActive(false);
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            panel.SetActive(false);
            talkingVologram.SetActive(false);
            idleVologram.SetActive(true);
        }
    }
}

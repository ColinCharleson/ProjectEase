using UnityEngine;
using TMPro;
using System.Collections;

public class VologramSwitch : MonoBehaviour
{
    public Transform baseNPC;
    public GameObject idleVologram;
    public GameObject talkingVologram;
    private GameObject currentState;
    public TextMeshProUGUI textComponent;
    public GameObject panel;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Start()
    {
        Destroy(currentState);
        currentState = Instantiate(idleVologram, baseNPC.position, baseNPC.rotation, baseNPC);
    }
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
        Destroy(currentState);
        currentState = Instantiate(talkingVologram, baseNPC.position, baseNPC.rotation, baseNPC);
        textComponent.text = string.Empty;
        StartDialogue();
        panel.SetActive(true);
    }

    // Call this method when you want to switch back to the idle vologram
    public void SwitchToIdle()
    {
        Destroy(currentState);
        currentState = Instantiate(idleVologram, baseNPC.position, baseNPC.rotation, baseNPC);
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
            Destroy(currentState);
            currentState = Instantiate(idleVologram, baseNPC.position, baseNPC.rotation, baseNPC);
        }
    }
}

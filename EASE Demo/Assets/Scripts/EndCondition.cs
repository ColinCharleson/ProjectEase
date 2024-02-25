using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EndCondition : MonoBehaviour
{
    public GameObject endUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endUI.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

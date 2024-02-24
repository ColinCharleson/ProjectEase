using UnityEngine;

public class VologramSwitcher : MonoBehaviour
{
    public GameObject idleVologram;
    public GameObject talkingVologram;

    // Call this method when you want to switch to the talking vologram
    public void SwitchToTalking()
    {
        idleVologram.SetActive(false);
        talkingVologram.SetActive(true);
    }

    // Call this method when you want to switch back to the idle vologram
    public void SwitchToIdle()
    {
        talkingVologram.SetActive(false);
        idleVologram.SetActive(true);
    }
}

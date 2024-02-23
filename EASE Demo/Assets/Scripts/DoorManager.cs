using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorManager : MonoBehaviour
{
    [Header("Door Properties")]
    [SerializeField] private float doorSpeed = 1;
    [SerializeField] private float doorLift = 5;
    private Vector3 endPos;

    [Header("Conditions")]
    [SerializeField] private Transform pushCube;
    [SerializeField] private Transform targetLocation;
    [SerializeField] private float cubeDistance = 0.5f;
    public bool doorStarted = false;
    public bool doorOpening = false;

    [Header("Conditions")]
    [SerializeField] private GameObject particles;

    public void Start() 
    {
        endPos = this.transform.position + Vector3.up * doorLift;
    }

    private void Update()
    {
        if (Vector3.Distance(pushCube.position, targetLocation.position) < cubeDistance && !doorStarted)
        {
            StartCoroutine(OpenDoor());
            doorStarted = true;
        }

        if(doorOpening)
            this.transform.position = Vector3.Lerp(this.transform.position, endPos, Time.deltaTime * (doorSpeed/10));
    }
    IEnumerator OpenDoor()
    {
        particles.SetActive(true);
        doorOpening = true;
        yield return new WaitForSeconds(doorLift * doorSpeed);
        particles.SetActive(false);
        doorOpening = false;
    }
}

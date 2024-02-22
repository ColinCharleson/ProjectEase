using System.Collections;
using System.Collections.Generic;
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
    private bool conditionsMet = false;

    public void Start() 
    {
        endPos = this.transform.position + Vector3.up * doorLift;
    }

    private void Update()
    {
        if (Vector3.Distance(pushCube.position, targetLocation.position) < cubeDistance)
            conditionsMet = true;

        if(conditionsMet)
            OpenDoor();
    }
    public void OpenDoor()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, endPos, Time.deltaTime * doorSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float lerpValue;
    [SerializeField] private Vector3 camPos, targetPos;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        distance = playerPos.position - transform.position;
    }

    private void LateUpdate()
    {
        if(gameManager.alive) Follow();
    }

    public void Follow()
    {
        camPos = transform.position;
        targetPos = playerPos.position - distance;
        camPos = Vector3.Lerp(camPos, targetPos, lerpValue * Time.deltaTime);
        transform.position = camPos;
    }
}

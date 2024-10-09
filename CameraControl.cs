using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public Transform farBackground, middleBackgroud;

    public float minHeight, maxHeight;

    //private float lastXPos;这里是水平的时候用的
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight),transform.position.z);

        // float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y-lastPos.y);
     
        farBackground.position = farBackground.position + new Vector3(amountToMove.x,amountToMove.y, 0f);

        middleBackgroud.position += new Vector3(amountToMove.x,amountToMove.y, 0f)*.5f;
        //lastXPos = transform.position.x;

        lastPos = transform.position;
    }
}

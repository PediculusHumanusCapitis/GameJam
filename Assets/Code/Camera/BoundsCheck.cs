using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;
    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    

    private void Awake() {
        camHeight= Camera.main.orthographicSize;
        camWidth = camHeight *Camera.main.aspect;
    }

    private void LateUpdate() {
        Vector3 pos = transform.position;
        isOnScreen=true;
        offRight = offLeft = offUp = offDown = false;

        if(pos.x>camWidth-radius){
            pos.x = camWidth-radius;
            isOnScreen=false;
            offRight = true;
        }

        if(pos.x<-camWidth+radius){
            pos.x = -camWidth+radius;
            isOnScreen=false;
            offLeft = true;
        }
        
        if(pos.y>camHeight-radius){
            pos.y = camHeight-radius;
            isOnScreen=false;
            offUp = true;
        }
        if(pos.y<-camHeight+radius){
            pos.y = -camHeight+radius;
            isOnScreen=false;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offDown || offUp);

        if(keepOnScreen && !isOnScreen){
            transform.position=pos;
            isOnScreen=true;
            offRight = offLeft = offUp = offDown = false;

        }
    }
}
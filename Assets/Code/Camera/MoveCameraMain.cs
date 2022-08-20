using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraMain : MonoBehaviour
{
    [SerializeField] private float _speed;


    private Vector3 currentVector = Vector3.up;
    private BoundsCheck bndCheck;
    private void Start(){
        bndCheck = GetComponent<BoundsCheck>();
        currentVector.z = transform.position.z;
        SetRandomVectorPos();

    }

     private void Update(){
        Move();


    }
    private void Move(){
        Vector3 pos = transform.position;
        transform.position = Vector3.Lerp(pos, currentVector, _speed * Time.deltaTime/10);
    }
     private void SetRandomVectorPos(){
        currentVector.x = Random.Range(-bndCheck.camWidth, bndCheck.camWidth);
        currentVector.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);
        Invoke("SetRandomVectorPos", 5f);
    }
}

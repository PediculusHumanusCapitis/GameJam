using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour, IMoving
{
    public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    [SerializeField] private int maxSpeed;
    private int speed;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;

    private void Start() {
        speed = MaxSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() {
        Move();
    }
    public void Move() {
        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        RotatePlayer(translationX);

        Vector3 movement = new Vector3(translationX, translationY, 0);
        rigidbody.velocity = movement;
    }
    public void RotatePlayer(float horizontalSpeed) {
        if(horizontalSpeed > 0) { 
            sprite.flipX = true;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if(horizontalSpeed < 0) {
            sprite.flipX = false;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}

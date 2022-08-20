using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour, IMoving
{
    public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    [SerializeField] private int maxSpeed;
    private int speed;
    private Rigidbody2D rigidbody;

    private void Start() {
        speed = MaxSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        Move();
    }
    public void Move() {
        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(translationX, translationY, 0);
        rigidbody.velocity = movement;
    }
}

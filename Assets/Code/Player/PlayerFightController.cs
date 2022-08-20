using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightController : MonoBehaviour, IAttacking
{   
    public int speedAttack = 5;
    public int rotateAttack = 30;
    public Transform weapon;
    private float rotateZ = 1;
    private int negativeSpeedAttack = -1;
    public void Start() {
        weapon.gameObject.SetActive(false);
        negativeSpeedAttack = -speedAttack;
    }
    public void Update() {
        Attack();
    }
    public void Attack() {
        if(Input.GetMouseButtonDown(0)) {
            weapon.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(RotateAttack());
        }
    }
    IEnumerator RotateAttack() {
        if(transform.rotation.y < 0) RotateWeapon(1);
        else if(transform.rotation.y > 0) RotateWeapon(-1);

        Vector3 newRotate = Vector3.zero;
        for(int i = 0; i <= rotateAttack / speedAttack; i++) {
            yield return new WaitForSeconds(0.02f);
            newRotate += new Vector3(0, 0, speedAttack * rotateZ);
            weapon.rotation = Quaternion.Euler(newRotate);
        }

        weapon.gameObject.SetActive(false);
        weapon.localRotation = Quaternion.Euler(Vector3.zero);
    }
    private void RotateWeapon(int newRotate) {
        if(rotateZ != newRotate) rotateZ *= -1;
    }
}

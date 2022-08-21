using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S

    public int gameNumber;
    // Start is called before the first frame update
    void Start() {
        S = this;
    }

    // Update is called once per frame
    public int GameNumber {
        get {
            return PlayerPrefs.GetInt("GameNumber", 0);
        }
        set {
            PlayerPrefs.SetInt("GameNumber", value);
        }
    }
    public int DamageHero() {
        get {
            return PlayerPrefs.GetInt("DamageHero", 0);
        }
        set {
            PlayerPrefs.SetInt("DamageHero", value);
        }
    }
    public int RotateAttackHero {
        get {
            return PlayerPrefs.GetInt("RotateAttackHero", 0);
        }
        set {
            PlayerPrefs.SetInt("RotateAttackHero", value);
        }
    }
}

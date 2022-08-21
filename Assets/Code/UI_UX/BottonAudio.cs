using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonAudio : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;

    public void Click(){
        clickAudio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Sound : MonoBehaviour
{
    SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = FindObjectOfType<SoundManager>();
    }


    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log("Room2 진ㅇ");
        Sound.Play();
        this.gameObject.SetActive(false);
    }
}

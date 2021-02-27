using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHearlth : MonoBehaviour
{
    [SerializeField] int totalHp = 10;
    [SerializeField] int hpDecrease = 1;
    [SerializeField] Text HealthText;
    [SerializeField] AudioClip playerDamageSFX;

    
    private void Start() 
    {
        HealthText.text = totalHp.ToString();
    }
    private void OnTriggerEnter(Collider other) 
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        totalHp -= hpDecrease;
        HealthText.text = totalHp.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int damagePerHit = 10;
    [SerializeField] Text healthText;

    void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
       health -= damagePerHit;
       healthText.text = health.ToString();
        if (health < 1)
        {         
            print("Player dead");
        }
    }

   
}

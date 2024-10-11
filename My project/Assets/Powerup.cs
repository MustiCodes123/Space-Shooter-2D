using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    // 0 = triple shot , 1 = speed , 2 = shields
    [SerializeField]
    private int powerupID;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -4f) {

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) { 
        
            Movement player = collision.transform.GetComponent<Movement>();
            if (player != null)
            {
                if (powerupID == 0) // triple shot
                {
                    player.tripleShotActive();
                }
                else if (powerupID == 1) {  // speed

                    player.SpeedBoostActive();
                
                }
                else if (powerupID == 2) { // shield
                    player.shieldPowerupActive();
                }
            }
            Destroy(this.gameObject);
        }
    }
}

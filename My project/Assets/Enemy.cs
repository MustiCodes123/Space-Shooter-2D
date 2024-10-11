using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed = 4.0f;
    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -3.8f) {

            transform.position = new Vector3(Random.Range(-8.9f, 8.5f), 5f, 0);
        }

      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Laser") || collision.transform.CompareTag("Player") ) {
            Movement player = collision.transform.GetComponent<Movement>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
       
    }
}

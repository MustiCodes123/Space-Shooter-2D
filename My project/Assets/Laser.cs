using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= 6f) {
            if (transform.parent != null) { 
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

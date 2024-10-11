using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float fireRate = 0.5f;
    private float canfire = -1f;
    [SerializeField]
    private int lives = 3;
    private SpawnManager spawnManager;
    private bool isTripleShotActive = false;
    [SerializeField]
    private GameObject tripleShot;
    private bool isSpeedPowerupActive = false;
    private bool isShieldActive = false;
    [SerializeField]
    private GameObject shieldVisualizer;
    [SerializeField]
    private int score;
    private uiManager _uiManager;



    private void Start()
    {

        transform.position = new Vector3(0, -2.50f, 0);
        spawnManager  = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<uiManager>();
    }


    private void Update()
    {
       
        CalculateMovement();
        if (Input.GetKey(KeyCode.Space) && Time.time > canfire) {
            InstantiateLaser();

        }

    }

    private void InstantiateLaser() {

        canfire = Time.time + fireRate;

        if (isTripleShotActive)
        {
            Instantiate(tripleShot, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }
    private void CalculateMovement() {

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

     
        transform.Translate(new Vector3(HorizontalInput, VerticalInput, 0) * speed * Time.deltaTime);
        
   

        if (transform.position.y >= 4.7)
        {

            transform.position = new Vector3(transform.position.x, 4.7f, 0);
        }
        else if (transform.position.y <= -3.6)
        {

            transform.position = new Vector3(transform.position.x, -3.6f, 0);
        }
        else if (transform.position.x >= 8.5)
        {

            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -8.9)
        {

            transform.position = new Vector3(-8.9f, transform.position.y, 0);
        }
    }

    public void SpeedBoostActive() {

        isSpeedPowerupActive = true;
        speed *= 2;
        StartCoroutine(speedBoostRoutine());

    }
    IEnumerator speedBoostRoutine()
    {
        yield return new WaitForSeconds(5f);
        speed /= 2;
        isSpeedPowerupActive = false;

    }

    public void Damage() {

        if (isShieldActive) { 
        
            isShieldActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        lives--;
        _uiManager.UpdateLives(lives);
        if (lives < 1) {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void tripleShotActive() { 
        isTripleShotActive = true;
        StartCoroutine(TripleShotTimer());

    }

    public void shieldPowerupActive() { 
    
        isShieldActive = true;
        shieldVisualizer.SetActive(true);
    }

    IEnumerator TripleShotTimer() {
        yield return new WaitForSeconds(5f);
        isTripleShotActive = false;

    }

    public void AddScore(int points) {
        score += points;
        _uiManager.updateScore(score);
    }
}

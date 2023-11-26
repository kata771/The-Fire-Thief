using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPower : MonoBehaviour
{
    public bool speedBoostChecker;
    public float boostDuration = 10f;

    private PlayerManager playerController;
    public GameObject player;

    private float originalSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = player.GetComponent<PlayerManager>();
        originalSpeed = playerController.heroSpeed;
    }

    void Start()
    {
        gameObject.tag = "SpeedBoost";
        speedBoostChecker = false;
    }

    // Speed boost Powerup
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !speedBoostChecker)
        {
            // Activate speed boost
            playerController.heroSpeed = 10;
            speedBoostChecker = true;
            gameObject.SetActive(false);

            // Schedule the speed reset after the specified duration
            Invoke("ResetSpeed", boostDuration);
        }
    }

    // Reset speed
    private void ResetSpeed()
    {
        playerController.heroSpeed = originalSpeed;
        speedBoostChecker = false;
    }
}
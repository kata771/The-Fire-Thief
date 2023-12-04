using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class inherits from PowerUp class (is a child).
/// This powerup contains logic for allowing player to boost.
/// </summary>
public class SpeedBoostPowerUp : PowerUp
{
    public bool speedBoostChecker;
    public float boostDuration = 10f;

    /// Old values, that are now in the parent class PowerUp
    //private PlayerManager playerController;
    //public GameObject player;

    private float originalSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        //playerController = player.GetComponent<PlayerManager>();
    }

    void Start()
    {
        //gameObject.tag = "SpeedBoost";
        //speedBoostChecker = false;
        originalSpeed = playerManager.heroSpeed; // ^

    }


    /// <summary>
    /// In this OnTriggerEnter2D we check if it's a player and then tell that it can use boost.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerManager.UseSpeedBoost(); // ^
            Destroy(gameObject);
        }
    }
}
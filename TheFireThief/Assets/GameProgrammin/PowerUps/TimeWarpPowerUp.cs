using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class inherits from PowerUp class (is a child).
/// This powerup contains logic for performing a timewarp.
/// </summary>
public class TimeWarpPowerUp : PowerUp
{
    /// <summary>
    /// In this OnTriggerEnter2D we check if it's a player.
    /// Then we tell Zeus gameobject to stop by changing initial velocity which I call a time warp.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (zeusManager != null)
            {
                zeusManager.SetInitialVelocity(0f);
            }

            // We destroy the object instead of deactivating it, as we don't need it anymore after collecting.
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}

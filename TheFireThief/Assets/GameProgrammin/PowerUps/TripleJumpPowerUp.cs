using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class inherits from PowerUp class (is a child).
/// This powerup contains logic for allowing player to perform triple jump.
/// </summary>
public class TripleJumpPowerUp : PowerUp
{
    /// <summary>
    /// In this OnTriggerEnter2D we check if it's a player and then tell that it can use triple jump.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerManager.SetIsAbleToTripleJump(); // ^
        }
    }
}

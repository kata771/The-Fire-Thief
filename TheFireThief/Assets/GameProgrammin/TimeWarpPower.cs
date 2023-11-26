using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///This class defines the TimeWarpPowerUp 
///

public class TimeWarpPower : MonoBehaviour
{
    public Zeus zeusScript; 

    /// if the colliding object has game tag "Player", makes the TimeWarpPowerUp GameObject disssapear, but does not delete it. 
    ///Method changes initialVelocity in class Zeus to 0f in case of collision with a GameObject of tag Player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            if (zeusScript != null)
            {
                zeusScript.SetInitialVelocity(0f);
            }
        }
      
    }
}

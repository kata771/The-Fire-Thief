using UnityEngine;

/// <summary>
/// Parent class that combines logic for all powerups.
/// Specific powerups still have their specific logic in their classes.
/// </summary>
public class PowerUp : MonoBehaviour
{
    public GameObject player;
    public PlayerManager playerManager;
    public GameObject zeus;
    public Zeus zeusManager;

    /// <summary>
    /// Method responsible for assigning player gameobject.
    /// </summary>
    /// <param name="p"> p as player </param>
    public void SetPlayer(GameObject p)
    {
        player = p;
        playerManager = player.GetComponent<PlayerManager>();
    }

    /// <summary>
    /// Method responsible for assigning zeus gameobject.
    /// </summary>
    /// <param name="z"> z as zeus </param>
    public void SetZeus(GameObject z)
    {
        zeus = z;
        zeusManager = zeus.GetComponent<Zeus>();
    }
}

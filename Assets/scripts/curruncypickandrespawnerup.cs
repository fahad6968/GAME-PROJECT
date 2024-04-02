using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    public float respawnRadius = 5f; // Radius around the player to respawn the coin
    public Text pickupText; // Reference to the UI Text element
    public Text coinCountText; // Reference to the UI Text element for displaying the coin count
    private static int coinCount = 0; // Static variable to keep track of the coin count

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag 'Player'.
        if (other.CompareTag("Player"))
        {
            // Call the method to handle the coin pickup.
            Pickup(other.transform);
        }
    }

    private void Pickup(Transform playerTransform)
    {
        // Increase the coin count.
        coinCount++;

        // Update the UI text to show the pickup message and the new coin count.
        pickupText.text = "Coin Collected!";
        coinCountText.text = "Coins: " + coinCount;

        // Respawn the coin at a random position near the player.
        RespawnNearPlayer(playerTransform);

        // Destroy the current coin object to simulate picking it up.
        Destroy(gameObject);

        // Optionally, hide the pickup message after a delay.
        StartCoroutine(HidePickupMessage());
    }

    private IEnumerator HidePickupMessage()
    {
        // Wait for 2 seconds.
        yield return new WaitForSeconds(2);
        // Clear the pickup message.
        pickupText.text = "";
    }

    private void RespawnNearPlayer(Transform playerTransform)
    {
        // Generate a random position within the respawn radius around the player.
        Vector3 randomDirection = Random.insideUnitSphere * respawnRadius;
        // Keep the coin on the same y-level as the player.
        randomDirection.y = 0;
        // Calculate the spawn position.
        Vector3 spawnPosition = playerTransform.position + randomDirection;

        // Instantiate a new coin at the calculated position.
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
}
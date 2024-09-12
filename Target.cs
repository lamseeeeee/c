using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using System.Collections; // Required for coroutines

public class Target : MonoBehaviour
{
    // Player's score (shared across all instances of this script)
    public static int score = 0;
    
    // Points awarded for hitting the target
    public int points = 5;
    
    // UI elements for displaying the score and the "Well Done" message
    public Text scoreText;
    public Text wellDoneText;

    void Start()
    {
        // Initialize the score display and hide the "Well Done" message
        UpdateScoreText();
        wellDoneText.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object that hit the target is tagged as "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Add points for hitting the target
            score += points;

            // Update the score text on the UI
            UpdateScoreText();

            // Check if the player has reached 50 points
            if (score >= 50)
            {
                // Show the "Well Done" message for 3 seconds
                StartCoroutine(DisplayWellDoneMessage());
            }

            // Destroy the bullet
            Destroy(collision.gameObject);

            // Move the target to a new random position
            ChangePosition();
        }
    }

    // Update the score text on the UI
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Move the target to a new random position
    void ChangePosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(1f, 5f);
        float randomZ = Random.Range(-10f, 10f);

        // Set the target's new random position
        transform.position = new Vector3(randomX, randomY, randomZ);
    }

    // Coroutine to display the "Well Done" message for 3 seconds
    IEnumerator DisplayWellDoneMessage()
    {
        // Show the "Well Done" message
        wellDoneText.gameObject.SetActive(true);

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Hide the "Well Done" message
        wellDoneText.gameObject.SetActive(false);
    }
}

using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{

    [SerializeField] private GameObject upgradeUIPanel;
    private bool isUpgradeUIActive = false; // Start with UI not active

    void Start()
    {
        if (upgradeUIPanel != null)
        {
            upgradeUIPanel.SetActive(isUpgradeUIActive);
        } else
        {
            Debug.LogWarning("Upgrade UI Panel is not assigned in the inspector.");
        }
    }

    void Update()
    {
        // This class will be for the visibility of the UI over the game.
        if (Input.GetKeyDown(KeyCode.U)) // Placeholder activation
        {
            // Toggle upgrade UI visibility
            Debug.Log("Toggling Upgrade UI");
            isUpgradeUIActive = !isUpgradeUIActive;
            upgradeUIPanel.SetActive(isUpgradeUIActive);
            if (isUpgradeUIActive)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Resume the game
            }
        }
    }

}

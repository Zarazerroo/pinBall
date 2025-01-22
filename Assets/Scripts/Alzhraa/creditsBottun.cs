using UnityEngine;

public class creditsBottun : MonoBehaviour
{
    public GameObject creditsPanel;

    public void ToggleCredits()
    {
        if (creditsPanel != null)
        {
            // Toggle the panel's active state
            creditsPanel.SetActive(!creditsPanel.activeSelf);
        }
    }

    public void CloseCredits()
    {
        if (creditsPanel != null)
        {
            // Hide the credits panel
            creditsPanel.SetActive(false);
        }
    }
}


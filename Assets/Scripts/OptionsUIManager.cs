using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    // References to each submenu GameObject
    public GameObject gameplayMenu;
    public GameObject audioMenu;
    public GameObject videoMenu;
    public GameObject accessibilityMenu;

    // Start by hiding all submenus
    void Start()
    {
        HideAllMenus();
    }

    // Show the Gameplay submenu
    public void ShowGameplayMenu()
    {
        HideAllMenus();
        gameplayMenu.SetActive(true);
    }

    // Show the Audio submenu
    public void ShowAudioMenu()
    {
        HideAllMenus();
        audioMenu.SetActive(true);
    }

    // Show the Video submenu
    public void ShowVideoMenu()
    {
        HideAllMenus();
        videoMenu.SetActive(true);
    }

    // Show the Accessibility submenu
    public void ShowAccessibilityMenu()
    {
        HideAllMenus();
        accessibilityMenu.SetActive(true);
    }

    // Hide all submenus (for the Main Menu button)
    public void HideAllMenus()
    {
        // This will hide all submenus
        gameplayMenu.SetActive(false);
        audioMenu.SetActive(false);
        videoMenu.SetActive(false);
        accessibilityMenu.SetActive(false);
    }
}

using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject playerSpeedUpgrade;
    private void Awake()
    {
        upgradeMenu.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            upgradeMenu.SetActive(!upgradeMenu.activeSelf);
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        }
    }
    
}

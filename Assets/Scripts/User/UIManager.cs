
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int bambooCount;
    public int laurelCount;
    public int pomegranateCount;
    public int oliveCount;
    public float waveTimer;
    public string currentTool;
    public bool alertActive;

    public Animator uiAnimationController;
    public Text bambooText;
    public Text laurelText;
    public Text pomegranateText;
    public Text oliveText;
    public Text waveTimerText;
    public GameObject alertPanel;
    public Text alertMessageText;
    
    private void Start()
    {
        HideAlert();
        //WaveManager.OnWaveChange += OnWaveChange;
        //ResourceManager.OnResourceChange += OnResourceChange;
    }

    public void UpdateResourceDisplay()
    {
        bambooText.text = "Bamboo: " + bambooCount;
        laurelText.text = "Laurel: " + laurelCount;
        pomegranateText.text = "Pomegranate: " + pomegranateCount;
        oliveText.text = "Olive: " + oliveCount;
    }

    public void UpdateWaveTimerDisplay()
    {
        waveTimerText.text = "Next Wave In: " + Mathf.Max(0, waveTimer).ToString("F1") + "s";
    }

    public void SelectTool(string toolName)
    {
        currentTool = toolName;
        // Additional UI updates for tool selection can be handled here
    }

    public void ShowAlert(string message)
    {
        alertMessageText.text = message;
        alertPanel.SetActive(true);
        alertActive = true;
        //AudioManager.PlayNotificationSound();
        uiAnimationController.SetTrigger("AlertTrigger");
    }

    public void HideAlert()
    {
        alertPanel.SetActive(false);
        alertActive = false;
    }

    public void OnResourceChange()
    {
        //bambooCount = ResourceManager.GetBambooCount();
        //laurelCount = ResourceManager.GetLaurelCount();
        //pomegranateCount = ResourceManager.GetPomegranateCount();
        //oliveCount = ResourceManager.GetOliveCount();
        UpdateResourceDisplay();
    }

    public void OnWaveChange()
    {
        //waveTimer = WaveManager.GetCurrentWaveTimer();
        UpdateWaveTimerDisplay();
    }

    private void OnDestroy()
    {
        //WaveManager.OnWaveChange -= OnWaveChange;
        //ResourceManager.OnResourceChange -= OnResourceChange;
    }
}

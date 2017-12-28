using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

[Serializable]
public class SettingsOption
{
    public bool arToggleValue;
    public bool soundToggleValue;
    public int qualityValue;
    public float volumeValue;

    public SettingsOption(bool arToggleValue, bool soundToggleValue, int qualityValue, float volumeValue)
    {
        this.arToggleValue = arToggleValue;
        this.soundToggleValue = soundToggleValue;
        this.qualityValue = qualityValue;
        this.volumeValue = volumeValue;
    }
}

public class SettingMenuController : ViewController
{
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle arToggle;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Dropdown qualityDropdown;
    [SerializeField] private Slider volumeSlider;

    private SettingsOption settingsOption = null;
    private bool isOnAR = false;

    private void Awake()
    {
       // settingMenu.SetActive(false);

        if (LoadSettings())
        {
            isOnAR = settingsOption.arToggleValue;

            QualitySettings.SetQualityLevel(settingsOption.qualityValue);

            if (settingsOption.soundToggleValue)
                audioMixer.SetFloat("volume", settingsOption.volumeValue);
            else
                audioMixer.SetFloat("volume", -80);
        }
    }

    private void OnEnable()
    {
        if (settingsOption == null)
            settingsOption = new SettingsOption(true, true, 2, 20);

        UpdateContent(settingsOption);
    }

    //Settings View 내용을 갱신
    public void UpdateContent(SettingsOption option = null)
    {
        arToggle.isOn = option.arToggleValue;
        soundToggle.isOn = option.soundToggleValue;
        qualityDropdown.value = option.qualityValue;
        volumeSlider.value = option.volumeValue;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        settingsOption.volumeValue = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        settingsOption.qualityValue = qualityIndex;
    }

    public void SetAR(bool isSetAR)
    {
        settingsOption.arToggleValue = isSetAR;
    }

    public void SetSound(bool isSetSound)
    {
        settingsOption.soundToggleValue = isSetSound;

        if (isSetSound)
            return;
        else
        {
            audioMixer.SetFloat("volume", -80);
        }
    }

    public void OnPressResetButton()
    {
        settingsOption.arToggleValue = arToggle.isOn = true;
        settingsOption.soundToggleValue = soundToggle.isOn = true;
        settingsOption.qualityValue = qualityDropdown.value = 2;
        settingsOption.volumeValue = volumeSlider.value = 20;

        QualitySettings.SetQualityLevel(2);
        audioMixer.SetFloat("volume", 20);
    }

    public void OnPressApplyButton()
    {
        SaveSettings();
        settingMenu.SetActive(false);
    }

    private void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(settingsOption, true);
        PlayerPrefs.SetString("SavedSettings", jsonData);
    }

    private bool LoadSettings()
    {
        if (!PlayerPrefs.HasKey("SavedSettings"))
            return false;
        else
        {
            string loadData = PlayerPrefs.GetString("SavedSettings");
            settingsOption = JsonUtility.FromJson<SettingsOption>(loadData);
            return true;
        }
    }
}

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
}

public class SettingMenuController : ViewController
{
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle arToggle;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Dropdown qualityDropdown;
    [SerializeField] private Slider volumeSlider;

    private static GameObject prefab = null;        //Settings View의 프리팹 저장
    private bool isPressApply=false;

    private void OnEnable()
    {
    }

    //Settings View를 표시하는 static 메서드
    public static SettingMenuController Show(SettingsOption option = null)
    {
        if(prefab == null)
        {
            prefab = Resources.Load("SettingMenu") as GameObject;
        }

        GameObject obj = Instantiate(prefab) as GameObject;
        SettingMenuController settingMenu = obj.GetComponent<SettingMenuController>();
        settingMenu.UpdateContent(option);

        return settingMenu;
    }

    //Settings View 내용을 갱신
    public void UpdateContent(SettingsOption option = null)
    {
        if (option == null)
        {
        }
        else
        {
            arToggle.isOn = option.arToggleValue;
            soundToggle.isOn = option.soundToggleValue;
            qualityDropdown.value = option.qualityValue;
            volumeSlider.value = option.volumeValue;
        }
    }

    public void OnPressResetButton()
    {

        Dismiss();
    }

    public void OnPressApplyButton()
    {
        if (isPressApply)
            PlayerPrefs.SetInt("PressApplyStatus", isPressApply ? 0 : 1);
        Dismiss();
    }

    //Settings View를 닫는 메서드
    public void Dismiss()
    {
        Destroy(gameObject);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetAR(bool isSetAR)
    {
     
    }

    public void SetSound(bool isSetSound)
    {
        
    }
}

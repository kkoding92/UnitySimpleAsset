using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct LogInInform
{
    public string id;
    public string pw;
}

[Serializable]
public struct LogInSettingsOption
{
    public bool isAutoLogIn;
    public bool isSetID;
}

public class LoginViewController : ViewController
{
	[SerializeField] private InputField	idInput;
	[SerializeField] private InputField pwInput;
	[SerializeField] private Toggle autoLogin;
	[SerializeField] private Toggle autoSetId;
	[SerializeField] private Button signInBtn;
	[SerializeField] private Button signUpBtn;
	[SerializeField] private GameObject loadingObj;

    private LogInInform logInInform;
    private LogInSettingsOption logInSettingsOption;

    private void Awake()
    {
        
    }

    private void Start () {
        signUpBtn.onClick.AddListener(delegate { SignUp(); });
        signInBtn.onClick.AddListener(delegate { LogIn(); });
        idInput.onEndEdit.AddListener(delegate { CheckIDInput(idInput); });
        pwInput.onEndEdit.AddListener(delegate { CheckPWInput(pwInput); });
    }

    private void CheckIDInput(InputField input)
    {
        if (input.text.Length != 0 && !(input.text.Contains("@") && input.text.Contains(".")))
        {
            AlertViewController.Show("", "메일 형식을 확인해주세요.");
            return;
        }
        logInInform.id = input.text;
    }

    private void CheckPWInput(InputField input)
    {
        if (input.text.Length != 0 && input.text.Length < 6)
        {
            AlertViewController.Show("", "비밀번호는 최소 6자 이상입니다.");
            return;
        }
        logInInform.pw = input.text;
    }
    
    private void SignUp()
    {
        SignupViewController.Show();
    }

    private void LogIn()
    {

    }

    //옵션 및 데이터 저장
    private void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(settingsOption, true);
        PlayerPrefs.SetString("SavedSettings", jsonData);
    }

    //저장된 데이터 유무 확인
    private bool LoadSettings()
    {
        if (!PlayerPrefs.HasKey("SavedSettings"))
            return false;
        else
        {
            //저장된 값을 파싱해 loadSettingsOption 객체에 담는다.
            string loadData = PlayerPrefs.GetString("SavedSettings");
            loadSettingsOption = JsonUtility.FromJson<SettingsOption>(loadData);
            return true;
        }
    }
}

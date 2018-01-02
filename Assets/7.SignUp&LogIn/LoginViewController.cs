using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct LogInInform
{
    public string id;
    public string pw;
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

    void Start () {
        logInInform = new LogInInform();
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
}

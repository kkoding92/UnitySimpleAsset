﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SignupViewController : ViewController 
{
	[SerializeField] private InputField idInput;
	[SerializeField] private InputField nameInput;
	[SerializeField] private InputField pwInput;
	[SerializeField] private InputField rePwInput;
	[SerializeField] private Button sendBtn;
	[SerializeField] private GameObject loadingObj;
	private string errTitle="오류";
	private string errMessage="입력하신 정보를 다시 확인해주세요.";

	private void Start () 
	{
		idInput.onEndEdit.AddListener(delegate {CheckIDInput(idInput); });
		nameInput.onEndEdit.AddListener(delegate {CheckNameInput(nameInput); });
		pwInput.onEndEdit.AddListener(delegate {CheckPWInput(pwInput); });
		rePwInput.onEndEdit.AddListener(delegate {CheckRePWInput(rePwInput); });
	}
	
	private void CheckIDInput(InputField input)
  {
    if (input.text.Length != 0 && !(input.text.Contains("@") && input.text.Contains(".")))
    {
			AlertViewController.Show(errTitle, errMessage );
		}
  }

	private void CheckNameInput(InputField input)
  {
		if(input.text.Length != 0 && (input.text.Length > 6 || input.text.Length < 2))
		{
			AlertViewController.Show(errTitle, errMessage );
		}
  }

	private void CheckPWInput(InputField input)
  {
		if(input.text.Length != 0 && input.text.Length < 6)
		{
      AlertViewController.Show(errTitle, errMessage );
		}
  }

	private void CheckRePWInput(InputField input)
  {
		if(input.text.Length != 0 && !input.text.Equals(pwInput.text))
		{
      AlertViewController.Show(errTitle, errMessage );
		}
  }

	public void OnPressSend()
	{
		if(idInput.text.Length == 0 || pwInput.text.Length == 0 || rePwInput.text.Length == 0 || nameInput.text.Length == 0)
		{
			string message = "빈칸을 확인해주세요";
			AlertViewController.Show(errTitle, message);
			return;
		}

							
	}
}

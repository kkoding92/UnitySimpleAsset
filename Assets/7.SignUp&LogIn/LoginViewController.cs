﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginViewController : ViewController {

	[SerializeField] private InputField	idInput;
	[SerializeField] private InputField pwInput;
	[SerializeField] private Toggle autoLogin;
	[SerializeField] private Toggle autoSetId;
	[SerializeField] private Button sigInBtn;
	[SerializeField] private Button signUpBtn;
	[SerializeField] private GameObject loadingObj;

	void Start () {
        signUpBtn.onClick.AddListener(delegate { SignUp(); });
	}
	
	void Update () {
		
	}

    private void SignUp()
    {
        SignupViewController.Show();
    }
}

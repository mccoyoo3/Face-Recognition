using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;
using Firebase;
using System.Net;
using System;
using Firebase.Database;
using TMPro;

public class MapView : UIView {

    public TMP_InputField _companyName;
    public TMP_InputField _userName;
    public TMP_InputField _password;
    public TMP_InputField _email;
    public TMP_InputField _firstName;
    public TMP_InputField _lastName;
    public TMP_InputField _displayName;
    public TMP_InputField _phoneNumber;
    public TMP_InputField _address;
    public TMP_InputField _zipCode;
    public TMP_Dropdown _country;
    public TMP_Dropdown _timeZone;
    public TMP_InputField _allowableRadius;
    public UserController userController;
    public bool isStudent;
    public UISegue segueToLoadingView;
    public UISegue segueToLogView;
    public LogView logView;

    private bool isCompanyClicked = false;
    private bool isStudentClicked = false;

    public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);

		//insert custom code here to be executed just before view will appear
	}

	public override void ViewAppeared () {
		base.ViewAppeared ();
        //insert custom code here to be executed after the view appeared
    }


	public override void ViewWillDissappear () {
		base.ViewWillDissappear ();

		//insert custom code here to be executed just before view will disappear
	}


	public override void ViewDisappeared () {
		base.ViewDisappeared ();

		//insert custom code here to be executed after view dissapeared
	}

    public void OnButtonClicked(int buttonNumber)
    {
        isCompanyClicked = buttonNumber == 1;
        isStudentClicked = buttonNumber == 2;
    }

    public void SomeLogic()
    {
        if (isCompanyClicked)
        {
            isStudent = false;
        }
        else if (isStudentClicked)
        {
            isStudent = true;
        }
    }

    public void EmptyField()
    {
        _companyName.text = string.Empty;
        _userName.text = string.Empty;
        _password.text = string.Empty;
        _email.text = string.Empty;
        _firstName.text = string.Empty;
        _lastName.text = string.Empty;
        _displayName.text = string.Empty;
        _phoneNumber.text = string.Empty;
        _address.text = string.Empty;
        _zipCode.text = string.Empty;
        _country.value = 0;
        _timeZone.value = 0;
        _allowableRadius.text = string.Empty;
    }

    public void OnCreateUserButtonClicked()
    {
        if (!IsValidEmail(_email.text))
        {
            LogView("Invalid email format.");
            return;
        }

        if (!string.IsNullOrEmpty(_zipCode.text) &&
            !string.IsNullOrEmpty(_allowableRadius.text))
        {
            string zipCodeText = _zipCode.text;
            string allowableRadiusText = _allowableRadius.text;

            if (int.TryParse(zipCodeText, out int zipCode) &&
                float.TryParse(allowableRadiusText, out float allowableRadius))
            {
                   userController.CreateUser(new UserModel(
                    _companyName.text, _userName.text, _password.text, _email.text,
                    _firstName.text, _lastName.text, _displayName.text,
                    long.Parse(_phoneNumber.text), _address.text, zipCode, _country.itemText.text,
                    _timeZone.itemText.text, allowableRadius, isStudent)
                );

                segueToLoadingView.Perform();
                EmptyField();
            }
            else
            {
                LogView("Invalid input for zip code, or allowable radius.");
            }
        }
        else
        {
            LogView("Zip code, and allowable radius fields must not be empty.");
        }
    }

    private void LogView(string log)
    {
        segueToLogView.Perform();
        logView.text.text = log;
    }

    private bool IsValidEmail(string email)
    {
        // Regular expression pattern for a simple email format validation
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
    }
}
		
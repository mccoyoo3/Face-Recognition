using UnityEngine.UI;
using UIToolkit.UI;
using TMPro;

public class AuthenticationView : UIView {

	public UISegue signUpView;
	public Button signUpButton;

    public TMP_InputField userName;
	public TMP_InputField password;
	public UserController userController;

	public UISegue segueToDashboard;

	public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);

        signUpButton.onClick.AddListener(OnSignUpUpdate);
        //insert custom code here to be executed just before view will appear
    }

	private void OnSignUpUpdate()
	{
		signUpView.Perform();
    }

    public void OnDashboard()
    {
        segueToDashboard.Perform();
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

    public void OnLogInButtonClicked()
    {
        if (string.IsNullOrEmpty(userName.text) ||
            string.IsNullOrEmpty(password.text))
		{
			return;
		}

		StartCoroutine(userController.LoginAsync(userName.text, password.text));
    }

}
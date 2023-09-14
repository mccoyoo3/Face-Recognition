using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;
using TMPro;

public class CompanySignUpView : UIView {

    public Button companySettingsButton;
	public UISegue companyAdditionalView;

    [SerializeField] private TMP_InputField companyInputField;
    [SerializeField] private TMP_InputField companyInputFieldother;

    public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);
        companyInputField.onValueChanged.AddListener(UpdateCompany);
        companySettingsButton.onClick.AddListener(OnCompanyUpdate);
        //insert custom code here to be executed just before view will appear
    }

    private void UpdateCompany(string company)
    {
        companyInputFieldother.text = company;
    }

    private void OnCompanyUpdate()
    {
        companyAdditionalView.Perform();
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
		
}
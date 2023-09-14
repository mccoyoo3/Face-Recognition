using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;

public class SignUpView : UIView {

	public Button companyButton;
	public UISegue companyView;

    public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);

        companyButton.onClick.AddListener(OnCompanyUpdate);
        //insert custom code here to be executed just before view will appear
    }

    private void OnCompanyUpdate()
    {
        companyView.Perform();
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
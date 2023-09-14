using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;

public class CompanySignUpAdditionalView : UIView {

    public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);
    }

	public override void ViewAppeared () {
		base.ViewAppeared ();
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

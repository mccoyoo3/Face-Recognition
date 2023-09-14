using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;
using TMPro;

public class LogView : UIView {
 
	public TextMeshProUGUI text;

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
		
}
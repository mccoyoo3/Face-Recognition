using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;

public class LoadingView : UIView {

	public UISegue segueToClose;

	public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);
		//insert custom code here to be executed just before view will appear
	}

	public override void ViewAppeared () {
		base.ViewAppeared ();
		StartCoroutine(DisplayLogInInterval());
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

	private IEnumerator DisplayLogInInterval()
	{
		yield return new WaitForSeconds(5f);
		segueToClose.Perform();

    }
		
}
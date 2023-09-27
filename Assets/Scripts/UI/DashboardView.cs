using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UIToolkit.UI;
using System;
using TMPro;

public class DashboardView : UIView {

	public TextMeshProUGUI dateText;

	public UISegue segueToEvents;
    public UISegue segueToFacialRecognition;

    public override void ViewWillAppear (UIView sourceView = null) {
		base.ViewWillAppear (sourceView);
        // Get the current date and format it as desired
        string currentDate = DateTime.Now.ToString("dd-MM-yyyy");

        // Set the text of the Text element to display the date
        dateText.text = currentDate;
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

	public void ShowEvents ()
	{
		segueToEvents.Perform();
    }

    public void ShowFacialRecognition()
    {
        segueToFacialRecognition.Perform();
    }

}
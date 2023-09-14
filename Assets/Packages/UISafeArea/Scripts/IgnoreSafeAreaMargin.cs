using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreSafeAreaMargin : MonoBehaviour {
    public UISafeArea SafeArea;
    public RectTransform RectTransform;

    public bool IgnoreTopMargin = false;
    public bool IgnoreBottomMargin = false;
    public bool IgnoreLeftMargin = false;
    public bool IgnoreRightMargin = false;
    
    private void OnEnable() {
        SafeArea.OnSafeAreaChanged += UpdateBottomMargin;
    }
    
    private void OnDisable() {
        SafeArea.OnSafeAreaChanged -= UpdateBottomMargin;
    }

    private void UpdateBottomMargin() {


        if (IgnoreBottomMargin) {
            RectTransform.offsetMin = new Vector2(RectTransform.offsetMin.x, -SafeArea.bottomMarginRectSize);
        }
        
        if (IgnoreTopMargin) {
            RectTransform.offsetMax = new Vector2(RectTransform.offsetMax.x, -SafeArea.topMarginRectSize);
        }

        if (IgnoreLeftMargin) {
            RectTransform.offsetMin = new Vector2(-SafeArea.leftMarginRectSize, RectTransform.offsetMin.y);
        }
        
        if (IgnoreRightMargin) {
            RectTransform.offsetMax = new Vector2(-SafeArea.rightMarginRectSize, RectTransform.offsetMax.y);
        }



    }
   
    
    
}

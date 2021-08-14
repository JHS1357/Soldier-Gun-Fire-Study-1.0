using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerCtrl : PlayerCtrl
{
    private Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    protected override void SetAnimation()
    {
        if (v >= 0.1f)
        {
            if(isRun)
                animation.CrossFade("RunF", 0.3f);
            else
                animation.CrossFade("WalkF", 0.3f);
        }
        else if (v <= -0.1f)
        {
            if (isRun)
                animation.CrossFade("RunB", 0.3f);
            else
                animation.CrossFade("WalkB", 0.3f);
        }
        else if (h >= 0.1f)
        {
            if (isRun)
                animation.CrossFade("RunR", 0.3f);
            else
                animation.CrossFade("WalkR", 0.3f);
        }
        else if (h <= -0.1f)
        {
            if (isRun)
                animation.CrossFade("RunL", 0.3f);
            else
                animation.CrossFade("WalkL", 0.3f);
        }
        else
        {
            animation.CrossFade("Idle", 0.3f);
        }
    }
}

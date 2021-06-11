using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit;

public class WatchFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
        if (handJointService != null)
        {
            Transform jointTransform = handJointService.RequestJointTransform(TrackedHandJoint.Wrist, Handedness.Left);
            this.transform.position = new Vector3(0f, 0.026f, 0f) + jointTransform.position;
            this.transform.rotation = Quaternion.Euler(new Vector3(-80f, 90f, 0f) + jointTransform.rotation.eulerAngles);
        }
    }
}

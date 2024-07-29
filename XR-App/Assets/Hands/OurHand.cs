using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.XR;

public class OurHand : MonoBehaviour
{

    public GameObject handPrefab;
    public InputDeviceCharacteristics ourControllerCharacteristics;
    
    private InputDevice ourDevice;

    // Start is called before the first frame update
    void Start()
    {
        InitializeOurHand();


    }
    void InitializeOurHand()
    {
        //Check our controller characteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            ourDevice = devices[0];

            GameObject newHand = Instantiate(handPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ourDevice.isValid)
        {
            UpdateOurHand();
        }
        else

        {
            InitializeOurHand();
        }
    }

    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float TriggerValue))
        {
            UnityEngine.Debug.Log("TriggerValue=" + TriggerValue);
        }
        else
        {
            UnityEngine.Debug.Log("Trigger Not active");
        }

        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float GripValue))
        {
            UnityEngine.Debug.Log("GripValue=" + GripValue);
        }
        else
        {
            UnityEngine.Debug.Log("Grip Not Active");
        }
    }
}

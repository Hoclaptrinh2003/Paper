using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    public List<GameObject> devices;

    private void OnEnable()
    {
        StartCoroutine(DisplayDevicesWithDelay());
    }

    private IEnumerator DisplayDevicesWithDelay()
    {
        foreach (GameObject device in devices)
        {
            HideAllDevices();

            device.SetActive(true);

            yield return new WaitForSeconds(1.2f);
        }
    }

    private void HideAllDevices()
    {
        foreach (GameObject device in devices)
        {
            device.SetActive(false);
        }
    }
}

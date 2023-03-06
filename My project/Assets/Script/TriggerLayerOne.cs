using System.Collections;
using UnityEngine;

public class TriggerLayerOne : MonoBehaviour
{
    public bool isEntered;

    [Header("Set Object Layer")]
    public GameObject One;
    public GameObject Two;
    public GameObject Three;
    public GameObject Four;
    public GameObject Five;

    [Header("Trigger Area")]
    public GameObject TriggerLayetOne;
    public GameObject TriggerLayetTwo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            isEntered = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            isEntered = false;
        }
    }

    private void Update()
    {
        StartCoroutine(Trigger());
    }

    IEnumerator Trigger()
    {
        if (isEntered)
        {
            One.layer = 0;
            Two.layer = 0;
            Three.layer = 9;
            Four.layer = 9;
            Five.layer = 9;

            yield return new WaitForSeconds(1f);

            TriggerLayetOne.SetActive(false);
            TriggerLayetTwo.SetActive(true);
        }
        isEntered = false;
    }
}

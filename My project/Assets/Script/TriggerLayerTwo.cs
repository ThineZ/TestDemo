using System.Collections;
using UnityEngine;

public class TriggerLayerTwo : MonoBehaviour
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
            One.layer = 7;
            Two.layer = 7;
            Three.layer = 0;
            Four.layer = 0;
            Five.layer = 0;

            yield return new WaitForSeconds(1f);

            TriggerLayetOne.SetActive(true);
            TriggerLayetTwo.SetActive(false);
        }
        isEntered = false;
    }
}

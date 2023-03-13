using UnityEngine;
using UnityEngine.InputSystem;

public class GravitySwitch : MonoBehaviour
{
    public bool isSwitched = false;

    public int SwitchCounter;

    private void Update()
    {
        Switch();

        if (SwitchCounter >= 5)
        {
            SwitchCounter = 0;
        }
    }

    private void Switch()
    {
        if (isSwitched)
        {
            SwitchCounter++;

            if (SwitchCounter == 1)
            {
                Physics.gravity = new Vector3(0f,0f,9.81f);
                transform.Rotate(-90f,0f,0f);
            }
            else if (SwitchCounter == 2)
            {
                Physics.gravity = new Vector3(0f, 9.81f, 0f);
                transform.Rotate(-180f,0f,0f);
            }
            else if (SwitchCounter == 3)
            {
                Physics.gravity = new Vector3(9.81f, 0f, 0f);
                transform.Rotate(-270f, 0f, 0f);
            }
            else if (SwitchCounter == 4)
            {
                Physics.gravity = new Vector3(0f, 9.81f, 0f);
                transform.Rotate(0f,0f,0f);
            }
        }
        isSwitched = false;
    }

    void OnGravitySwitch(InputValue switchValue)
    {
        isSwitched = true;
    }
}

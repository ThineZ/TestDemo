using UnityEngine;

public class PlateLogic : MonoBehaviour
{
    [Header("Pickable Object")]
    public GameObject PickableObject;
    
    [SerializeField] private bool isPressure = false;

    public float Ypos;
    public Rigidbody PlateRB;
    public GameObject Plate;

    [Header("Door")]
    public Animator DoorAnim;
    public Material ExitLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickableObject" || other.gameObject.tag == "TargetedSpaces")
        {
            isPressure = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickableObject" || other.gameObject.tag == "TargetedSpaces")
        {
            isPressure = false;
        }
    }


    private void Update()
    {
        if (isPressure == true)
        {
            PlateRB.isKinematic = false;
            //Debug.Log("Is Trigger");
            DoorAnim.SetBool("ifTrigger", true);
            ExitLight.color = Color.green;
        }

        if(isPressure == false)
        {
            Plate.transform.localPosition = new Vector3(gameObject.transform.position.x, Ypos, gameObject.transform.position.z);
            PlateRB.isKinematic = true;
            //Debug.Log("Is Not Trigger");
            DoorAnim.SetBool("ifTrigger", false);
            ExitLight.color = Color.red;
        }
    }
}

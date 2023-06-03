using UnityEngine;

public class speech_swap : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public float switchDelay = 1.0f; // Delay between object switches in seconds
    private GameObject activeObject;

    private void Start()
    {
        // Start with object1 active
        ActivateObject(object1);

        // Start the repeating object switch with the specified delay
        InvokeRepeating("SwitchObjects", switchDelay, switchDelay);
    }

    private void ActivateObject(GameObject objectToActivate)
    {
        if (activeObject != null)
        {
            activeObject.SetActive(false);
        }

        activeObject = objectToActivate;
        activeObject.SetActive(true);
    }

    private void SwitchObjects()
    {
        if (activeObject == object1)
        {
            ActivateObject(object2);
        }
        else
        {
            ActivateObject(object1);
        }
    }
}

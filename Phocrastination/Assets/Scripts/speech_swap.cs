using UnityEngine;

public class speech_swap : MonoBehaviour
{
    public GameObject speech1, speech2;
    private GameObject active;
    public float switchDelay = 1.0f;

    private void Start()
    {
        speech1.SetActive(true);
        speech2.SetActive(false);
        active = speech1;


        // Start the repeating object switch with the specified delay
        InvokeRepeating("SwitchObjects", switchDelay, switchDelay);
    }

    private void SwitchObjects() {
        if (active == speech1) {
            speech1.SetActive(false);
            speech2.SetActive(true);
            active = speech2;
        } else {
            speech1.SetActive(true);
            speech2.SetActive(false);
            active = speech1;
        }
    }
}

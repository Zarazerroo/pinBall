// All rights reserved 2025 Muhammad Alhasan. Unauthorized copying, distribution, or modification is prohibited.


using UnityEngine;

public class PinballFlicker : MonoBehaviour
{
    [Header("Flicker Settings")]
    public float flickerAngle = 45f; 
    public float flickSpeed = 10f; 
    public KeyCode flickKey = KeyCode.Space; 

    private Quaternion initialRotation; 
    private Quaternion targetRotation; 
    private bool isFlicking = false; 

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -flickerAngle));
    }

    private void Update()
    {
        HandleFlicker();
    }

    private void HandleFlicker()
    {
        if (Input.GetKeyDown(flickKey) && !isFlicking)
        {
            StartCoroutine(Flick());
        }
    }

    private System.Collections.IEnumerator Flick()
    {
        isFlicking = true;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, flickSpeed * Time.deltaTime * 100);
            yield return null;
        }

        while (Quaternion.Angle(transform.rotation, initialRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, flickSpeed * Time.deltaTime * 100);
            yield return null;
        }

        isFlicking = false;
    }





}

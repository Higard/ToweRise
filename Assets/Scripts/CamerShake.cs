using UnityEngine;

public class CamerShake : MonoBehaviour
{
    private Transform camTransform;
    private float shakeDur = 1f, shakeAmount = 0.04f, decreseFactor = 1.5f;
    private Vector3 origionPosition;

    private void Start()
    {
        camTransform = GetComponent<Transform>();
        origionPosition = camTransform.localPosition;
    }

    private void Update()
    {
        if (shakeDur > 0)
        {
            camTransform.localPosition = origionPosition + Random.insideUnitSphere * shakeAmount;
            shakeDur -= Time.deltaTime * decreseFactor;
        }
        else
        {
            shakeDur = 0;
            camTransform.localPosition = origionPosition;
        }
    }
}

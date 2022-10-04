using UnityEngine;

public class CmRotation : MonoBehaviour
{

    public float speed = 10f;
    private Transform rotate;
    void Start()
    {
        rotate  = GetComponent<Transform>();
    }

    void Update()
    {
        rotate.Rotate(0, speed * Time.deltaTime, 0);
    }
}

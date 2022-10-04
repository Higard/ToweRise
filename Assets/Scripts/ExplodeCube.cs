using UnityEngine;
using System.Collections;

public class ExplodeCube : MonoBehaviour
{

    public GameObject restartButton, explosion;
    private bool colSet;
    public bool LooseStatus;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cube" && !colSet)
        {
            for (int i = collision.transform.childCount - 1; i >= 0; i--)
            {
                Transform child = collision.transform.GetChild(i);
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f, Vector3.up, 5f);
                child.SetParent(null);
            }
            restartButton.SetActive(true);
            Camera.main.transform.position -= new Vector3(0, 0, 3f);
            Camera.main.gameObject.AddComponent<CamerShake>();

            GameObject newVfx = Instantiate(explosion, new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z), Quaternion.identity) as GameObject;
            Destroy(newVfx, 3f);
            if (PlayerPrefs.GetString("music") != "No")
                GetComponent<AudioSource>().Play();

                Destroy(collision.gameObject);
            colSet = true;
        }
    }
}

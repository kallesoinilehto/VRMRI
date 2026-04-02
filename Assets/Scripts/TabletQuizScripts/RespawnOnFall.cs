using UnityEngine;
using System.Collections;

public class RespawnOnFall : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;
    private bool isRespawning = false;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallZone"))
        {
            Respawn();
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && !isRespawning)
        {
            StartCoroutine(RespawnWithDelay(1f));
        }
    }

    IEnumerator RespawnWithDelay(float delay)
    {
        isRespawning = true;

        yield return new WaitForSeconds(delay);

        Respawn();

        isRespawning = false;
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
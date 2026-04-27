using UnityEngine;
using System.Collections;

public class RespawnOnFall : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;
    private bool isRespawning = false;

    // tallennetaan objektin sijainti ja rotaatio alussa
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Jätin tähän OnTriggerEnter()-metodin siltä varalta, että lobbyn FallZone otetaan käyttöön
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallZone"))
        {
            Respawn();
        }
    }*/

    // jos objekti, johon tämä script on linkitetty törmää lattiaan (jolla on "Floor" tag), kutsutaan RespawnWithDelay-korutiinia
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

        // viive ennen respawnia
        yield return new WaitForSeconds(delay);

        // kutsutaan Respawn()-metodia
        Respawn();

        isRespawning = false;
    }

    void Respawn()
    {
        // varmistetaan, että objekti pysyy paikallaan respawnissa
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // nykyinen sijainti muutetaan alun sijainniksi
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
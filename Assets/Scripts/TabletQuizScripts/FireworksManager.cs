using UnityEngine;

public class FireworksManager : MonoBehaviour
{
    // t‰h‰n linkitet‰‰n inspectorissa fireworks-efekti
    public ParticleSystem fireworks;

    public void PlayFireworks()
    {
        // k‰ynnistet‰‰n efekti
        fireworks.Play();
    }
}
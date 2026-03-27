using UnityEngine;

public class FireworksManager : MonoBehaviour
{
    public ParticleSystem fireworks;

    public void PlayFireworks()
    {
        fireworks.Play();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerAnimationScript : MonoBehaviour
{
    private Animator mAnimator;
    private ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    void Awake()
    {
        mAnimator = GetComponent<Animator>();
        ParticleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(PlayAnimationAndParticles());
    }

    public void GetSticker()
    {
        mAnimator.SetTrigger("ReceiveSticker");
    }

    public void DoParticles()
    {
        ParticleSystem.Play();
    }

    IEnumerator PlayAnimationAndParticles()
    {
        Debug.Log("Playing sticker animation");
        yield return new WaitForSeconds(1);
        GetSticker();
        Debug.Log("middle animation");
        yield return new WaitForSeconds(2);
        DoParticles();
        Debug.Log("End animation");
    }
}

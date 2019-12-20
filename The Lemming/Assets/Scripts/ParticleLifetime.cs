using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetime : MonoBehaviour
{
    public AnimationClip anim;

    private float lifeTime;
    private float remainingLifeTime;

    private void Awake()
    {
        lifeTime = anim.length;
        remainingLifeTime = lifeTime;
    }

    private void OnEnable()
    {
        remainingLifeTime = lifeTime;
    }

    private void Update()
    {
        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime < 0)
            gameObject.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField]
    AudioClip asteroidExplosion = default;
    [SerializeField]
    AudioClip spaceshipExplosion = default;
    [SerializeField]
    AudioClip fire = default;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AsteroidExplosion()
    {
        audioSource.PlayOneShot(asteroidExplosion, 0.4f);
    }
    public void SpaceshipExplosion()
    {
        audioSource.PlayOneShot(spaceshipExplosion);
    }
    public void Fire()
    {
        audioSource.PlayOneShot(fire);
    }
}

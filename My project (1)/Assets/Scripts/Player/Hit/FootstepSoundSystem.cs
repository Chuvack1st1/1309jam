using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSoundSystem : MonoBehaviour
{
    public AudioClip GrassStep;
    public AudioClip RockStep;

    private AudioSource audioSource;

    private PlayerRotaion2 playerRotaion;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        playerRotaion = GetComponentInParent<PlayerRotaion2>();
    }

    private void Update()
    {
        if (playerRotaion.InputDirection.x > 1 ||
                            playerRotaion.InputDirection.z > 1)
        {
            audioSource.pitch = 1.25f;
        }
        else
        {
            audioSource.pitch = 1f;
        }
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, 2f))
        {
            if (hit.collider.gameObject.TryGetComponent(out Terrain terrain))
            {
                audioSource.clip = GrassStep;
                if (playerRotaion.InputDirection != Vector3.zero)
                    if (!audioSource.isPlaying)
                        audioSource.Play();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;

    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalMaterial = spriteRenderer.material;
    }


    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;

        flashCoroutine = null;
    }

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashRoutine());
    }


}

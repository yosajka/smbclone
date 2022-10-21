using System.Collections;
using UnityEngine;

public class Pirana : MonoBehaviour
{
    public float delayTime = 0f;
    
    private bool animatable = true;

    

    private void OnEnable()
    {
        if (animatable)
        {
            InvokeRepeating(nameof(StartAnimate), delayTime, 7f);
        }
         
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Hit();
        }
    }

    private void StartAnimate()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        animatable = false;
        
        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition = startPosition + Vector3.up * 1.5f;

        yield return Move(startPosition, endPosition);
        yield return Move(endPosition, startPosition);

        animatable = true;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 3f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}

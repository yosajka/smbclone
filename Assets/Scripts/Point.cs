using System.Collections;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SpawnAnimation());
    }

    private IEnumerator SpawnAnimation()
    {
        float elapsed = 0f;
        float duration = 1f;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * 2f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = endPosition;

        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class PipeWarp : MonoBehaviour
{
    public int nextStage;
    public int nextWorld;
    
    public KeyCode enterKeyCode = KeyCode.S;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(enterKeyCode))
            {
                StartCoroutine(Move(other.transform, transform.position + Vector3.down, Vector3.one * 0.5f));
                
            }
        }
    }

    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;

        Vector3 startPosition = player.position;
        Vector3 startScale = player.localScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            player.position = Vector3.Lerp(startPosition, endPosition, t);
            player.localScale = Vector3.Lerp(startScale, endScale, t);

            elapsed += Time.deltaTime;

            yield return null;
        }
        
        player.position = endPosition;
        player.localScale = endScale;

        GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }
    
}

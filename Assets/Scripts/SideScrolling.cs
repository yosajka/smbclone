
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;

        if (transform.position.y > 0f)
        {
            Camera.main.backgroundColor = new Color(0.3607843f, 0.5803922f, 0.9882353f, 0);
        }
        else
        {
            Camera.main.backgroundColor = Color.black;
        }
    }

    public void SetUnderground(Vector3 position)
    {
        transform.position = position;
    }
}

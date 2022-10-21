using UnityEngine.Tilemaps;
using UnityEngine;


public class Destructible : MonoBehaviour
{
   private Tilemap destructibleBrick;
   public GameObject tempBrick;
   public GameObject _breakParticles;


   private bool animating;

   private void Awake()
   {
        destructibleBrick = GetComponent<Tilemap>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y > 0)
            {
                Vector3 hitPosition = Vector3.zero;
                ContactPoint2D hit = collision.contacts[0];
                
                hitPosition.x = hit.point.x + 0.5f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.5f * hit.normal.y;

                Vector3Int tileCellPosition = destructibleBrick.WorldToCell(hitPosition);
                Vector3 tileWorldPosition = destructibleBrick.GetCellCenterWorld(tileCellPosition);

                destructibleBrick.SetTile(tileCellPosition, null);

                Instantiate(tempBrick, tileWorldPosition, Quaternion.identity);
                
            } 
        }
   }

   public void SpawnParticles(Vector3 position)
   {
        Instantiate(_breakParticles, position, Quaternion.identity);
   }

}

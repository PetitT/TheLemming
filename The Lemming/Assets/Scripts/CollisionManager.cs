using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public int browniePoints;
    public int giftPoints;
    public int sugarPoints;
    public int skullPoints;
    public int rainPoints;
    public int planePoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            string name = collision.GetComponent<PoolTag>().poolName;

            switch (name)
            {
                case "Brownie":
                    Collide(collision, browniePoints, DecorPool.instance.niceParticlePool);
                    break;

                case "Gift":
                    Collide(collision, giftPoints, DecorPool.instance.niceParticlePool);
                    break;

                case "Sucre":
                    Collide(collision, sugarPoints, DecorPool.instance.niceParticlePool);
                    break;

                case "Skull":
                    Collide(collision, skullPoints, DecorPool.instance.wrongParticlePool);
                    break;

                case "RainCloud":
                    Collide(collision, rainPoints, DecorPool.instance.wrongParticlePool);
                    break;

                case "Plane":
                    Collide(collision, planePoints, DecorPool.instance.wrongParticlePool);
                    break;

                default:
                    break;
            }

        }

    }

    private void Collide(Collider2D collision, int points, List<GameObject> pool)
    {
        ScoreManager.instance.ChangeScore(points);
        DecorPool.instance.GetParticle(pool, collision.gameObject.transform.position);
        collision.gameObject.SetActive(false);
    }
}

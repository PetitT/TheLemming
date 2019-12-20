using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public int browniePoints;
    public int giftPoints;
    public int sugarPoints;
    public int skullPoints;
    public int rainPoints;
    public int planePoints;

    public int skullDamage;
    public int rainDamage;
    public int planeDamage;

    private int layer;
    public SpriteRenderer lemming;
    public GameObject decor;

    private void Start()
    {
        layer = lemming.sortingLayerID;
    }

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
                    HealthManager.instance.TakeDamage(skullDamage);
                    break;

                case "RainCloud":
                    Collide(collision, rainPoints, DecorPool.instance.wrongParticlePool);
                    HealthManager.instance.TakeDamage(rainDamage);
                    break;

                case "Plane":
                    Collide(collision, planePoints, DecorPool.instance.wrongParticlePool);
                    HealthManager.instance.TakeDamage(planeDamage);
                    break;

                default:
                    break;
            }

        }

    }

    private void Collide(Collider2D collision, int points, List<GameObject> pool)
    {
        ScoreManager.instance.ChangeScore(points);
        GameObject particle =  DecorPool.instance.GetParticle(pool, collision.gameObject.transform.position);
        TextMeshPro newText = particle.GetComponentInChildren<TextMeshPro>();
        particle.transform.SetParent(decor.transform);
        newText.text = points.ToString();
        newText.sortingOrder = 15;
        newText.sortingLayerID = layer;
        collision.gameObject.SetActive(false);
    }
}

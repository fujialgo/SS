using UnityEngine;
using System.Collections;

public class EnemyAttackObj : MonoBehaviour
{
    public int mPower
    {
        get; set;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit "+other.tag);
        if (other.transform.tag == "Wall")
        {
            other.transform.GetComponent<WallScript>().mHp -= mPower;
            DestroyObject(gameObject);
        }
    }
}

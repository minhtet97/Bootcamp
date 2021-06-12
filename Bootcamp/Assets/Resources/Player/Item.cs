using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    fSpeed,
    bSpeed,
    rSpeed,
}
public class Item : MonoBehaviour
{
    public GameObject m_gameobj;
    public ItemType m_type = ItemType.None;
    public float m_num = 0.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_gameobj, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}

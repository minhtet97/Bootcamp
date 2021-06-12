using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaControll : MonoBehaviour
{
    public Vector3 m_velocity = Vector3.zero;
    public float m_forwardSpeed = 7.0f;
    public float m_backSpeed = 4.0f;
    public float m_rotSpeed = 2.0f;
    public float animSpeed = 1.5f;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;

        m_velocity = new Vector3(0, 0, v);

        m_velocity = transform.TransformDirection(m_velocity);
        
        if(v > 0.1)
        {
            m_velocity *= m_forwardSpeed;
        }else if(v < -0.1)
        {
            m_velocity *= m_backSpeed;
        }

        transform.localPosition += m_velocity * Time.fixedDeltaTime;

        transform.Rotate(0, h * m_rotSpeed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Item hittem = collision.gameObject.GetComponent<Item>();
            if (hittem == null) return;

            switch(hittem.m_type)
            {
                case ItemType.fSpeed:
                    m_forwardSpeed = hittem.m_num;
                    break;
                case ItemType.bSpeed:
                    m_backSpeed = hittem.m_num;
                    break;
                case ItemType.rSpeed:
                    m_rotSpeed = hittem.m_num;
                    break;
                default:
                    break;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionEixt(Collision collision)
    {

    }


}

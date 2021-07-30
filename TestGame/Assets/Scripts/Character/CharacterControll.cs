    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private SpriteRenderer m_SpriteRenderer;
    private CircleCollider2D m_circleCollider2D;

    [SerializeField] public LayerMask m_layer;

    public float movespeed = 1f;
    public float jumpspeed = 1f;
    public Values pos;
    public Vector3 position;

    public INV_Info Inventory_Info;

    void Start()
    {
        //transform.position = pos.playerPosition;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        float size = Input.GetAxis("Horizontal");
        float jump_check = Input.GetAxis("Jump");
        Vector3 movement = new Vector3(size, 0f, 0f);

        m_Rigidbody2D.transform.position += movement * Time.deltaTime * movespeed;
        switch (size)
        {
            case -1:
                {
                    m_SpriteRenderer.flipX = true;
                    break;
                }
            case 1:
                {
                    m_SpriteRenderer.flipX = false;
                    break;
                }
        }
        //if (Input.GetKeyUp(KeyCode.A)) { m_SpriteRenderer.flipX = true;  }

        //if (Input.GetKeyUp(KeyCode.D)) { m_SpriteRenderer.flipX = false; }

        if (m_circleCollider2D.IsTouchingLayers(m_layer) && Input.GetAxis("Jump")==1)
        {
            m_Rigidbody2D.AddForce(transform.up * jumpspeed, ForceMode2D.Impulse);
            //m_Rigidbody2D.AddForce(new Vector2(0f, jumpspeed),ForceMode2D.Impulse);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TriggeredObj>() == null)
        {
            return;
        }

        Inventory_Info.LastTriggeredName = collision.gameObject.GetComponent<TriggeredObj>().TriggerName;
        Inventory_Info.LastTriggeredObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TriggeredObj>() == null)
        {
            return;
        }

        Inventory_Info.LastTriggeredName = default;
        Inventory_Info.LastTriggeredObject = default;
    }
}

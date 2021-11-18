using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private Vector3 moveDelta;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        speed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        moveDelta = Vector3.zero;
        float y = Input.GetAxisRaw("Vertical");
        
        moveDelta = new Vector3(0, y, 0);
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size-new Vector2(0.6f,0.6f), 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * speed), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {   
            transform.Translate(0, moveDelta.y * speed, 0);
        }
    }
}

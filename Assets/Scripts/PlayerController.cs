using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canMove = true;
    [SerializeField]
    private float maxPos;
    [SerializeField]
    private float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        var position = transform.position;
        position += MoveSpeed * inputX * Time.deltaTime * Vector3.right;
        
        float xPos = Mathf.Clamp(position.x, -maxPos, maxPos);
        position = new Vector3(xPos, position.y, position.z);
        transform.position = position;
    }
}

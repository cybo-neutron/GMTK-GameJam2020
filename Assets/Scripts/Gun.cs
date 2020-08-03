using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]Transform gunPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newDir = mouseposition - (Vector2)transform.position;
        float dir = Mathf.Atan2(newDir.y, newDir.x) * Mathf.Rad2Deg ;
        //transform.rotation = Quaternion.Euler(gunPivot.position.x,gunPivot.position.y,dir);
        transform.rotation = Quaternion.Euler(transform.position.x,transform.position.y,dir);

        
    }
}

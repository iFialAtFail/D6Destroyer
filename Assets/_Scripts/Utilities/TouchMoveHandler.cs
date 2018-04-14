using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchMoveHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("MoveGravWell") > 0)
        {
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var origin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            var direction = Vector3.forward;

            RaycastHit[] hits = Physics.RaycastAll(origin, direction, 1000f, LayerMask.GetMask("TouchHandler"));
            Debug.DrawRay(origin, direction, Color.red, 100f);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.tag == "gravWell" && hit.collider.gameObject.activeInHierarchy)
                {
                    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -5));
                    transform.position = new Vector3(transform.position.x,transform.position.y, 5);
                }
            }

        }
    }
}

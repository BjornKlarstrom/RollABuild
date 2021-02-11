using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathDrawer : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.SetActive(true);
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, 200, LayerMask.GetMask("Ground")))
            {
                this.transform.position = hitInfo.point;
            }
        }
    }
}

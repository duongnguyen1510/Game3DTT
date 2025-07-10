using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class RemoveTank : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private Camera camera;

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, layer))
                {
                   TitleMap titleMap = hit.transform.GetComponent<TitleMap>();
                   if (titleMap != null && titleMap.HasTank())
                   {
                       Tank tank = titleMap.GetTank();
                       if (tank != null)
                       {
                           Destroy(tank.gameObject);
                           titleMap.removeTank();
                       }
                   }
                }
            }
        }
    }
}

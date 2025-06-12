using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Duong
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private Camera camera;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, layer))
                {
                    Debug.Log(hit.transform.gameObject.name);
                }
            }
        }
    }
}

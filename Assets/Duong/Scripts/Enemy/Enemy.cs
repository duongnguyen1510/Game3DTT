using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class Enemy : MonoBehaviour
    {
        public List<TitleMap> ListPath = new List<TitleMap>();
        [SerializeField] Animator animator;
        public float speed = 1f;

        public void SetUpData(List<TitleMap> ListPath)
        {
            this.ListPath = new List<TitleMap>(ListPath);
        }

        public void Update()
        {
            
            TitleMap titleTarget = ListPath[0];
            Vector3 positionTarget = titleTarget.transform.position;
            if (ListPath.Count == 1)
            {
                positionTarget.x += 2f;
            }
            float distance = Vector3.Distance(titleTarget.transform.position, transform.position);
            if (distance > 0.28f)
            {
                Vector3 direction = (positionTarget - transform.position).normalized;
                    if (direction != Vector3.zero) 
                    {
                        Quaternion lookRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); 
                    }
                    animator.SetBool("isRun", true);
                transform.position = Vector3.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
            }
            else
            {
                ListPath.RemoveAt(0);
                if (ListPath.Count <= 0)
                {
                    animator.SetBool("isRun", false);
                    Destroy(gameObject);
                }
            }
        }
    }
}

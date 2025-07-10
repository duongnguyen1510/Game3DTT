using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    public class Enemy : MonoBehaviour
    {
        [Space, Header("Animation")]
        [SerializeField] Animator _animator;
        [SerializeField] private Transform _transPosTarget;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _colorHit;
        [SerializeField] private Color _colorDefault;

        public Transform TransPosTarget
        {
            get => _transPosTarget;
        }
        
        private List<TitleMap> ListPath = new List<TitleMap>();
        private float speed = 1f;
        private float healthCurrent = 50;
        private Material materialCurrent;
        private Coroutine coroutine;

        public bool isDie;
        public bool allowedToShoot;

        public void SetUpData(List<TitleMap> ListPath)
        {
            this.ListPath = new List<TitleMap>(ListPath);
            materialCurrent = _renderer.material;
            _animator.SetBool("isDie", false);
            _animator.SetBool("isRun", false);
            isDie = false;
            allowedToShoot = false;
        }
        
        public void Update()
        {
            if (GameManager.StartGameCurrent != EStartGame.PLAY)
            {
                return;
            }
            if (isDie)
            {
                return;
            }
            if (ListPath.Count > 0)
            {
                TitleMap titleTarget = ListPath[0];
                Vector3 positionTarget = titleTarget.transform.position;
                if (ListPath.Count == 1)
                {
                    positionTarget.x += 2f;
                }
                Vector3 positionTarget2 = new Vector3(positionTarget.x, transform.position.y, positionTarget.z);
                float distance = Vector3.Distance(transform.position, positionTarget2);
                if (distance > 0.28f)
                {
                    Vector3 direction = (positionTarget - transform.position).normalized;
                    if (direction != Vector3.zero)
                    {
                        Quaternion lookRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                    }

                    _animator.SetBool("isRun", true);
                    transform.position = Vector3.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
                }
                else
                {
                    ListPath.RemoveAt(0);
                    allowedToShoot = true;
                    if (ListPath.Count <= 0)
                    {   
                        _animator.SetBool("isRun", false);
                        ManagerEnemy.Instance.ListEnemy.Remove(this);
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                allowedToShoot = false;
            }
            
        }
        
        public void TakeDamage(float damage)
        {
            if (healthCurrent > 0)
            {
                healthCurrent -= damage;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(ChangeColor(materialCurrent, _colorDefault, _colorHit, 0.1f, 0.1f));
                if (healthCurrent <= 0)
                {
                    isDie = true;
                    _animator.SetBool("isDie", true);
                    float timeDeath = GetTimePlayAnimation("Death");
                    timeDeath += 0.1f;
                    StartCoroutine(IWaitDeath(timeDeath));
                }
            }
        }

        private IEnumerator IWaitDeath(float timeDeath)
        {
            yield return new WaitForSeconds(timeDeath);
            Death();
        }

        private float GetTimePlayAnimation(string animName)
        {
            RuntimeAnimatorController controller = _animator.runtimeAnimatorController;
            float timeDuration = 0;
            foreach (var clip in controller.animationClips)
            {
                if (clip.name == animName)
                {
                    timeDuration = clip.length;
                    break;
                }
            }
            return timeDuration;
        }

        private void Death()
        {
            ManagerEnemy.Instance.EnemyDeath();
            ManagerEnemy.Instance.ListEnemy.Remove(this);
            Destroy(gameObject);
        }
        
        public IEnumerator ChangeColor(Material material, Color fromColor, Color toColor, float duration, float timeWait)
        {
            yield return StartCoroutine(LerpColor(material, fromColor, toColor, duration));
            yield return new WaitForSeconds(timeWait);
            StartCoroutine(LerpColor(material, toColor, fromColor, duration));
        }
        private IEnumerator LerpColor(Material material, Color fromColor, Color toColor, float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                material.color = Color.Lerp(fromColor, toColor, time / duration);
                yield return null;
            }
            material.color = toColor;
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Duong
{
    public class ChooseTilleMap : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private Camera camera;
        
        private TitleMap titleMapCache;
        
        [SerializeField] private Tank tankPrefab;
        private Tank tankCache;
        

        void Update()
        {
            if (GameManager.StartGameCurrent != EStartGame.PLAY)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, layer))
                {
                    TitleMap titleMap = hit.transform.GetComponent<TitleMap>();
                    if (titleMap != null && titleMapCache != titleMap)
                    {
                        if (titleMapCache != null)
                        {
                            titleMapCache.EnableOutLine(false);
                        }

                        if (tankCache != null)
                        {
                            Destroy(tankCache.gameObject);
                        }
                        titleMapCache = titleMap;
                        if (titleMapCache.typeMap == TitleMapType.Tank)
                        {
                            if (!titleMapCache.HasTank())
                            {
                                titleMapCache.EnableOutLine(true);
                                tankCache = Instantiate(tankPrefab, transform);
                                tankCache.EnableRaneAtt(true);
                                tankCache.transform.position = titleMapCache.transform.position;
                                tankCache.Intialize();
                                
                                titleMapCache.SetTank(tankCache);
                            }
                        }
                    }
                }
                else
                {
                    if (titleMapCache != null)
                    {
                        titleMapCache.EnableOutLine(false);
                        titleMapCache = null;
                    }

                    if (tankCache != null)
                    {
                        tankCache.EnableRaneAtt(false);
                        Destroy(tankCache.gameObject);
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (titleMapCache != null)
                {
                    titleMapCache.EnableOutLine(false);
                    titleMapCache = null;
                }

                if (tankCache != null)
                {
                    tankCache.ActiveTank();
                    tankCache.EnableRaneAtt(false);
                    tankCache = null;
                }
            }
        }
    }
}

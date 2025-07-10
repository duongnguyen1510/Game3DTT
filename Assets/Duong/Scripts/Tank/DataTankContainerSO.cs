using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duong
{
    [CreateAssetMenu(menuName = "Data/DataTankContainerSO",fileName = "DataTankContainerSO")]
    public class DataTankContainerSO : ScriptableObject
    {
        [SerializeField] private int _maxLevel;
        [SerializeField] private List<DataTankSO> _dataTankSO;

       public List<DataTankSO> ListDataTankSO
       {
           get => _dataTankSO;
       }

       public int MaxLevel
       {
           get => _maxLevel;
       }

       public DataTankSO GetDataTankSO(int id)
       {
           foreach (var item in ListDataTankSO)
           {
               if (item.Data.idTank == id)
               {
                   return item;
               }
           }
           return null;
       } 
    }
}

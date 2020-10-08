using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class SelectorDropzone : MonoBehaviour
{
    public List<GameObject> _listSnapDropZone = new List<GameObject>();// ссылки на дроп зоны объкотов которые можно разместить в той же точке что и тот который пользователь держит в данный момент времени
    public bool _stay;

    //private void Update()
    //{
    //    if (_stay == true)
    //    {
    //        SelectorDropZoneDisable();
    //    }
    //    else
    //    {
    //            //Thread.Sleep(1000);
    //            SelectDropZoneEnable();
    //    }
    //}

    public void SelectorDropZoneDisable()
    {
        Debug.Log("101");
        for (int i = 0; i < _listSnapDropZone.Count; i++)
        {
            Debug.Log("151645464");
            _listSnapDropZone[i].SetActive(false);
        }
    }

    public void SelectDropZoneEnable()
    {
            //Debug.Log("202");

        for (int i = 0; i < _listSnapDropZone.Count; i++)
        {
            _listSnapDropZone[i].SetActive(true);
        }
    }
}


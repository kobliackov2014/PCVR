using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Данный скрипт определяет какой компонент в данный момент закреплен в зоне тригерров 
/// </summary>
public class TrigerZone : MonoBehaviour
{
    public string _componentType;

    public GameObject _enteredObject;

    public bool _stayComponent = false;

    [Tooltip("Укажите ссылку на мэнеджера тригер зон ")]
    public ManagerTriggerZone _managerTriggerZone;
    [Tooltip("Обект который закрепляется в данном тригере")]
    public GameObject _allowedObject;
    public SelectorDropzone selectorDropzone;

    //private void Start()
    //{
    //    selectorDropzone = _gameObjectSelector.GetComponent<SelectorDropzone>();
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == _componentType)
        {
            _stayComponent = true;

            _enteredObject = other.gameObject;
            Debug.Log("3333333");

            if (_allowedObject.name == other.name)
            {
                Debug.Log("22222222");
                selectorDropzone.SelectorDropZoneDisable();

            }

            //_managerTriggerZone._CPU = _enteredObject;

            //_managerTriggerZone._stayCPU = _stayCPU;

            _managerTriggerZone.OutLogCPU(_componentType, _stayComponent, _enteredObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _componentType)
        {
            _stayComponent = false;
            if (_allowedObject.name == other.name)
            {
                selectorDropzone.SelectDropZoneEnable();

            }

            _managerTriggerZone.OutLogCPU(_componentType, _stayComponent, _enteredObject);
            Debug.Log($"Компонент {_componentType} отсутствует");
        }
    }
}

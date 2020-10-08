using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTriggerZone : MonoBehaviour
{
    private TrigerZone _trigerZone;

    [Tooltip("Укажите тег для процессора")]
    public string _tag_CPU;
    // Не забудь сделать эти параметры приватными
    public GameObject _gameObject_CPU;
    public bool _stay_CPU = false;

    [Tooltip("Укажите тег для куллера процессора процессора")]
    public string _tag_Culler_CPU;
    // Не забудь сделать эти параметры приватными
    public GameObject _gameObject_Culler_CPU;
    public bool _stay_Culler_CPU = false;

    [Tooltip("Укажите тег для видеокарты")]
    public string _tag_GPU;
    // Не забудь сделать эти параметры приватными
    public GameObject _gameObject_GPU;
    public bool _stay_GPU = false;

    [Tooltip("Укажите тег для блока питания")]
    public string _tag_PSU;
    // Не забудь сделать эти параметры приватными
    public GameObject _gameObject_PSU;
    public bool _stay_PSU = false;
    Characteristics_CPU _charact_CPU;

    [Tooltip("Укажите тег для ОЗУ")]
    public string _tag_RAM;
    // Не забудь сделать эти параметры приватными
    public int _number_RAM = 0;//текущее количество установленых модулей
    public List<GameObject> _gameObject_RAM = new List<GameObject>(); // массив ссылок на GameObject ОЗУ
    //public GameObject _gameObject_RAM;
    public bool _stay_RAM = false;

    [Tooltip("Укажите тег для ПЗУ")]
    public string _tag_ROM;
    // Не забудь сделать эти параметры приватными
    //public GameObject _gameObject_ROM;
    public int _number_ROM = 0;//текущее количество установленых модулей
    public List<GameObject> _gameObject_ROM = new List<GameObject>();// Массив ссылок на GameObject ПЗУ
    public bool _stay_ROM = false;


    public void OutLogCPU (string _componentType, bool _stayComponent, GameObject _enteredObject)
    {  
        if (_tag_CPU == _componentType)
        {
            if (_stayComponent == true)
            {
                _stay_CPU = _stayComponent;
                _gameObject_CPU = _enteredObject;
                Debug.Log("Состояние процессора - установлен.\n" + $"Cтоит {_enteredObject.name}");

                //_charact_CPU = _gameObject_CPU.GetComponent(typeof(Characteristics_CPU)) as Characteristics_CPU;
            }
            else if (_stayComponent == false)
            {
                _stay_CPU = _stayComponent;
                _gameObject_CPU = null;
                Debug.Log("Состояние процессора - не установлен");
            }
        }
        else if (_tag_Culler_CPU == _componentType)
        {
            if (_stayComponent == true)
            {
                _stay_Culler_CPU = _stayComponent;
                _gameObject_Culler_CPU = _enteredObject;
                Debug.Log("Состояние куллера процессора - установлен.\n" + $"Cтоит {_enteredObject.name}");

                
            }
            else if (_stayComponent == false)
            {
                _stay_Culler_CPU = _stayComponent;
                _gameObject_Culler_CPU = null;
                Debug.Log("Состояние кулера процессора -  не установлен");
            }
        }
        else if (_tag_GPU == _componentType)
        {
            if (_stayComponent == true)
            {
                _stay_GPU = _stayComponent;
                _gameObject_GPU = _enteredObject;
                Debug.Log("Состояние GPU - установлен.\n" + $"Cтоит {_enteredObject.name}");

                
            }
            else if (_stayComponent == false)
            {
                _stay_GPU = _stayComponent;
                _gameObject_GPU = null;
                Debug.Log("Состояние GPU -  не установлен");
            }
        }
        else if (_tag_PSU == _componentType)
        {
            if (_stayComponent == true)
            {
                _stay_PSU = _stayComponent;
                _gameObject_PSU = _enteredObject;
                Debug.Log("Состояние куллера процессора - установлен.\n" + $"Cтоит {_enteredObject.name}");


            }
            else if (_stayComponent == false)
            {
                _stay_PSU = _stayComponent;
                _gameObject_PSU = null;
                Debug.Log("Состояние кулера процессора -  не установлен");
            }
        }
        else if (_tag_RAM == _componentType)
        {
            if (_stayComponent == true)
            {
                _number_RAM = _number_RAM + 1;
                _stay_RAM = _stayComponent;
                _gameObject_RAM.Add(_enteredObject);
                Debug.Log("Состояние RAM - установлен.\n" + $"Cтоит {_enteredObject.name}");

            }
            else if (_stayComponent == false)
            {
                _gameObject_RAM.Remove(_enteredObject);
                Debug.Log($"Извлечен модуль ОЗУ{_enteredObject}");

                //Проверяем остались ли еще модули и в случае когда все слоты пусты меняем состояие переменной
                _number_RAM = _number_RAM - 1;
                if(_number_RAM == 0)
                {
                    _stay_RAM = _stayComponent;
                    Debug.Log("Состояние RAM -  не установлен");
                }
                
            }
        }
        else if (_tag_ROM == _componentType)
        {
            if (_stayComponent == true)
            {
                _stay_ROM = _stayComponent;
                _gameObject_ROM.Add(_enteredObject);
                Debug.Log("Состояние RAM - установлен.\n" + $"Cтоит {_enteredObject.name}");


            }
            else if (_stayComponent == false)
            {
                _gameObject_RAM.Remove(_enteredObject);
                Debug.Log($"Извлечен модуль ПЗУ {_enteredObject}");

                //Проверяем остались ли еще модули и в случае когда все слоты пусты меняем состояие переменной
                _number_ROM = _number_RAM - 1;
                if (_number_ROM == 0)
                {
                    _stay_ROM = _stayComponent;
                    Debug.Log("Состояние ROM -  не установлен");
                }
            }
        }
    }
}

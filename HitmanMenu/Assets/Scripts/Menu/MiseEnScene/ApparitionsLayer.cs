using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApparitionsLayer : MonoBehaviour
{
    public List<ObjectDatas> Objs;

    [Header ("Event")]
    public float FrequenceCall;
    public UnityEvent CallEvent;

    float _value;

    [System.Serializable]
    public class ObjectDatas
    {
        public GameObject Obj;
        public float Time;
    }

    private void Start()
    {
        if(Objs.Count!=0)
        {
            foreach (ObjectDatas o in Objs)
                o.Obj.SetActive(false);
            StartCoroutine(StartMenu());
        }
    }

    IEnumerator StartMenu()
    {
        foreach (ObjectDatas o in Objs)
        {
            yield return new WaitForSeconds(o.Time);
            o.Obj.SetActive(true);
        }
    }

    private void Update()
    {
        if (FrequenceCall == 0)
            return;

        _value += Time.deltaTime/FrequenceCall;
        if(_value>1)
        {
            _value = 0;
            CallEvent.Invoke();
        }
    }

}

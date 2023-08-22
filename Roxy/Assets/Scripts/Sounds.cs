using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sounds : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{

    static public bool Sounds_On = true;
    private void OnEnable()
    {
        if (Sounds_On)
        {
            GetComponent<Animator>().Play("Sounds_On");
        }
        else
        {
            GetComponent<Animator>().Play("Sounds_Off");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Sounds_On)
        {
            Sounds_On = false;
            GetComponent<Animator>().Play("Sounds_Off");
        }
        else
        {
            Sounds_On = true;
            GetComponent<Animator>().Play("Sounds_On");
        }
    }



}

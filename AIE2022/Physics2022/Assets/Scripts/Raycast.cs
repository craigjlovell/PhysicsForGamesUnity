using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Text output;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500) == true)
        {
            //output.text = hit.transform.gameObject.name;
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(hit.transform.gameObject);
        }

    }
    
}

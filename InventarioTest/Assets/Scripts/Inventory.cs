using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Item[] item;
    public LojaItens[] lojaItem;

    //test
    //public GameObject[] slot;

    //public GameObject[] txtSlot;

    //public Text[] txtSQ;

    public GameObject mouseItem;
    int cont = 0;

    private void Start()
    {
        //slot = new GameObject[6];
        /*txtSlot = new GameObject[6];
        txtSQ = new Text[6];
        for(int x = 1; x < 7; x++)
        {
            //slot[cont = x - 1] = GameObject.Find("Slot" + x);
            txtSlot[cont = x - 1] = item[cont = x - 1].ga.transform.GetChild(0).transform.GetChild(0).gameObject;
            txtSQ[cont = x - 1] = txtSlot[cont].GetComponent<Text>();
        }*/
    }
    private void Update()
    {

        /*for(int x = 1; x < 7; x++)
            txtSQ[cont = x - 1].text = item[cont = x - 1].quantidade.ToString();*/

        for(int x = 0; x < 6; x++)
        {
            item[x].txtQuant.text = item[x].quantidade.ToString();
        }
    }
    public void DragItem(GameObject button)
    {
        mouseItem = button;
        mouseItem.transform.position = Input.mousePosition;
    }
    public void ClickItem(GameObject button)
    {
        mouseItem = button;
    }
    public void DropItem(GameObject button)
    {
        if(mouseItem != null)
        {
            //usar a variavel auxiliar para trocar os botoes
            Transform aux = mouseItem.transform.parent;

            mouseItem.transform.SetParent(button.transform.parent);
            button.transform.SetParent(aux);
        }
    }
    public void ConsumeItem()
    {
        if (UIManager.instance.pyMoney > 0)
        {
            //Verificar o objeto consumido e subtrair
            for (int a = 0; a < 6; a++)
            {
                //item[a].quantidade.ToString() = 
                if (item[a].id == mouseItem.name)
                {
                    Debug.Log(mouseItem.name);
                    item[a].quantidade--;
                    UIManager.instance.pyMoney--;
                    UIManager.instance.pyLife += item[a].iLife;
                    UIManager.instance.pyPower += item[a].iPower;
                    UIManager.instance.pyRes += item[a].iRes;
                    UIManager.instance.pyShild += item[a].iShild;
                    if (item[a].quantidade < 1)
                    {
                        mouseItem.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}

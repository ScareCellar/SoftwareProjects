using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject masterContainer;
    public GameObject buyContainer;
    public GameObject sellContainer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            masterContainer.SetActive(false);
        }
        if(sellContainer.activeSelf == true)
        {

        }
    }

    public void BuyButton()
    {
        sellContainer.SetActive(false);
        buyContainer.SetActive(true);
    }

    public void SellButton()
    {
        buyContainer.SetActive(false);
        sellContainer.SetActive(true);
    }

    public void MarketButton()
    {
        masterContainer.SetActive(true);
        if(buyContainer.activeSelf == false && sellContainer.activeSelf == false)
        {
            buyContainer.SetActive(true);
        }
    }
}

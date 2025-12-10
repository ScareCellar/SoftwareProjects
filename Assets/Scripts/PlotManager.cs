using System.Collections;
using System.Collections.Generic;
using RealAssets.CurrencySystem;
using RealAssets.InventorySystem;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    SpriteRenderer plot;

    Currency currency;

    PlantObject selectedPlant;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = GetComponent<SpriteRenderer>();
        currency = Currency.Singleton;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage<selectedPlant.plantStages.Length-1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                GivePlayerSeed(selectedPlant);
                Harvest();
            }
        }
        else if(fm.isPlanting)
        {
            Plant(fm.selectPlant.plant);
        }

    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if(isPlanted || Inventory.CurrentlySelectedSlot.CurrentItem == null)
            {
                //can't buy
                plot.color = unavailableColor;
            }
            else
            {
                //can buy
                plot.color = availableColor;
            }
        }
    }

    // private void OnMouseExit()
    // {
    //     plot.color = Color.white;
    // }

    private void GivePlayerSeed(PlantObject plant)
    {
        Inventory.Singleton.AddItem(plant);
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        //fm.Transaction(selectedPlant.sellPrice); Transaction should be done with Market
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;

        // fm.Transaction(-selectedPlant.buyPrice);
        // Should be done by buying seeds from market; aka this needs to be connected to Inventory

        // This line clears the currently selected inventory slot after planting
        Inventory.CurrentlySelectedSlot.ClearSlot();

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0,plant.bounds.size.y/2);
    }

}

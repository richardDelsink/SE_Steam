using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApp
{
    public class ShopCart
    {
        public List<ShopItems> Items { get; set; }
        public static readonly ShopCart Instance;

        // hoeft alleen maar te lezen
        static ShopCart()
        {
            // als session niet gelijk aan null is niuew shocart met shopitems
            if (HttpContext.Current.Session["ShoppingCart"] == null)
            {
                Instance = new ShopCart();
                Instance.Items = new List<ShopItems>();
                HttpContext.Current.Session["ShoppingCart"] = Instance;
            }
            else
            {
                Instance = (ShopCart) HttpContext.Current.Session["ShoppingCart"];
            }
        }

        protected ShopCart()
        {
            
        }

        #region zelfde item toevoegen
        // toevoegen van meerde zelfde soort items anders geeft het 1
        public void AddItem(int ItemID)
        {
            ShopItems newItem = new ShopItems(ItemID);
            if (Items.Contains(newItem))
            {
                foreach (ShopItems item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }
        #endregion

        #region aantal van item neerzetten
        // hoeveel van de item neerzetten
        public void SetItemQuantity(int itemid, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(itemid);
            }

            ShopItems updatedItems = new ShopItems(itemid);

            foreach (ShopItems item in Items)
            {
                if (item.Equals(updatedItems))
                {
                    item.Quantity = quantity;
                    
                }
            }
        }
        #endregion

        #region verwijderen van item
        // verwijderen van de item
        public void RemoveItem(int itemid)
        {
            ShopItems removedItems = new ShopItems(itemid);
            Items.Remove(removedItems);
        }
        #endregion
        #region totaal bereken van items
        // totaal krijgen van alle items
        public int GetSubTotal()
        {
            int subTotal = 0;
            foreach (ShopItems item in Items)
            {
                subTotal += item.TotalCost;
            }
            return subTotal;
        }
        #endregion
    }
}
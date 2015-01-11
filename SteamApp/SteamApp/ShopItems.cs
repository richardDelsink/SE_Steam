using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace SteamApp
{
    //interface kijken of hetzelfde object is
    public class ShopItems: IEquatable<ShopItems>
    {
        public int Quantity { get; set; }
        private int itemid;

        public int Itemid
        {
            get { return itemid; }
            set { itemid = value; }
        }

        private Item item = null;

        public Item ITEM
        {
            get
            {
                if (item == null)
                {
                    item = new Item(Itemid);
                }
                return item;
            }
        }

        public string ItemInfo
        {
            get { return ITEM.ItemInfo; }
        }

        public int IsCost
        {
            get { return ITEM.IsCost; }
        }

        public int TotalCost
        {
            get { return IsCost * Quantity; }
        }

        public string ItemName
        {
            get { return ITEM.ItemName; }
        }

        public ShopItems(int itemid)
        {
            this.Itemid = itemid;
        }

        public bool Equals(ShopItems item)
        {
            return item.Itemid == this.Itemid;
        }

    }
}
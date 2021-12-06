using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Credit/References:

#1 Image to Byte[]: -
Taken from user answer nima at https://stackoverflow.com/questions/4653095/how-to-store-images-using-entity-framework-code-first-ctp-5
User suggested switching using byte array. referenceImage was set as Image class before suggestion. Used this code and the database accepted it.
*/

namespace AdvancedProgrammingGroup9
{
    //this is all the types of orders
    enum OrderType
    {
        Sword = 0,
        Armour = 1
    }

    //intertface for order items - used to define all the common code
    public interface IOrderItems
    {
        int GetID();
        string GetName();
        int GetQuantity();
        byte[] GetReferenceImage();
        int GetTime();
    }

    public class OrderItems : IOrderItems
    {
        /*
            The purpose of this class is to allow the saving of OrderItems into the database.
            Before the orderItems was using an interface, it still does but the subtypes now
            inherit from this orderItems class.
        */

        [Key]
        public int itemID { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public int quantity { get; set; }
        //referenceImage is optional for the user - this code was modified based on stack overflow (#1).
        public byte[] referenceImage { get; set; }
        [Required]
        public int creationTime { get; set; }
        [Required]
        public virtual Order Order { get; set; }

        public OrderItems(String itemName, int quantity, byte[] referenceImage)
        {
            this.name = itemName;
            this.quantity = quantity;
            this.referenceImage = referenceImage;
        }

        public int GetID()
        {
            return itemID;
        }
        public string GetName()
        {
            return name;
        }
        public int GetQuantity()
        {
            return quantity;
        }
        public byte[] GetReferenceImage()
        {
            return referenceImage;
        }
        public int GetTime()
        {
            return creationTime;
        }
    }

    //Item factory, create a item based on the type passed into the factory (sword, armour, etc)
    class ItemFactory
    {
        private static ItemFactory instance;
        private ItemFactory() { }
        //singleton, checking to see if a factor has already been created.
        public static ItemFactory Singleton
        {
            get
            {
                if (instance == null)
                    instance = new ItemFactory();
                return instance;
            }
        }

        //used to get the item types and create a new object based on the type.
        public OrderItems GetItemTypes(OrderType orderType, string name, int quantity, byte[] referenceImage)
        {
            if (orderType == OrderType.Sword)
                return new SwordItem(name, quantity, referenceImage);
            else
                //if (orderType == OrderType.Armour)
                return new ArmourItem(name, quantity, referenceImage);

        }
    }

    //sword item class
    public class SwordItem : OrderItems //IOrderItems
    {
        public SwordItem(string name, int quantity, byte[] referenceImage) : base(name, quantity, referenceImage)
        {
            this.creationTime = 120;
        }
    }

    //armour item class
    public class ArmourItem : OrderItems
    {
        public ArmourItem(string name, int quantity, byte[] referenceImage) : base(name, quantity, referenceImage)
        {
            this.creationTime = 300;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

/*
Credit/References:

#1 Image to Byte[]: -
Taken from user answer nima at https://stackoverflow.com/questions/4653095/how-to-store-images-using-entity-framework-code-first-ctp-5
User suggested switching using byte array. referenceImage was set as Image class before suggestion. Used this code and the database accepted it.
*/

namespace DomainLayer
{
    //this is all the types of orders
    enum OrderType
    {
        Sword = 0,
        Armour = 1,
        CeremonialSword = 2
    }

    //intertface for order items - used to define all the common code
    public interface IOrderItemsModel
    {
        void SaveItem(OrderItems orderitems);
        int GetMaxTime();
        int GetMinTime();
    }

    public class OrderItemsModel : IOrderItemsModel
    {
 
        //used to calculate the range
        protected int maxCreationTime { get; set; }
        protected int minCreationTime { get; set; }

        protected IDatabaseCreateQueries create;
        OrderItems orderitems;

        public OrderItemsModel(IDatabaseCreateQueries create)
        {
            this.create = create;
        }

        public void SaveItem(OrderItems orderitems)
        {
            create.SaveOrderItem(orderitems);
        }

        public int GetMaxTime()
        {
            return maxCreationTime;
        }
        public int GetMinTime()
        {
            return minCreationTime;
        }
    }

    /*
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
        public OrderItemsModel GetItemTypes(OrderType orderType)
        {
            if (orderType == OrderType.Sword)
                return new SwordItem();
            else if (orderType == OrderType.Armour)
                return new ArmourItem();
            else
                return new CeremonialSwordItem();
        }
    }

    
    //sword item class
    public class SwordItem : OrderItemsModel //IOrderItems
    {
        public SwordItem() : base(IDatabaseCreateQueries create)
        {
            this.maxCreationTime = 120;
            this.minCreationTime = 80;
        }
    }

    //armour item class
    public class ArmourItem : OrderItemsModel
    {
        public ArmourItem() : base()
        {
            this.maxCreationTime = 300;
            this.minCreationTime = 80;
        }
    }

    //CeremonialSword item class
    public class CeremonialSwordItem : OrderItemsModel //IOrderItems
    {
        public CeremonialSwordItem() : base()
        {
            this.maxCreationTime = 30;
            this.minCreationTime = 20;
        }
    }

    */
}

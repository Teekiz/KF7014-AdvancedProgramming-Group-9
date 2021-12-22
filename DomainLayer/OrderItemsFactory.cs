using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    //this is all the types of orders
    public enum OrderType
    {
        Sword = 0,
        Armour = 1,
        CeremonialSword = 2
    }


    //Item factory, create a item based on the type passed into the factory (sword, armour, etc)
    public class ItemFactory
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
        public OrderItems GetItemTypes(OrderType orderType)
        {
            if (orderType == OrderType.Sword)
                return new SwordItem();
            else if (orderType == OrderType.Armour)
                return new ArmourItem();
            else
                return new CeremonialSwordItem();
        }
    }
}

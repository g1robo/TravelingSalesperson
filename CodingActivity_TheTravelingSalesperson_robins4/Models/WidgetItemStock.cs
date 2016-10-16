using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson
{
    public class ProductsItemStock
    {
        #region ENUMERABLES

        public enum ProductsType
        {
            None,
            Pizzas,
            Cheeseburgers,
            Tacos,
            Eggrolls,
        }

        #endregion
        
        #region FIELDS

        private ProductsType _type;
        private int _numberOfUnits;

        #endregion

        
        #region PROPERTIES

        public ProductsType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
        }

        #endregion


        #region CONSTRUCTORS

        public ProductsItemStock()
        {
            _type = ProductsType.None;
            _numberOfUnits = 0;
        }

        public ProductsItemStock(ProductsType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }

        #endregion


        #region METHODS

        /// <summary>
        /// add widgets to the inventory
        /// </summary>
        /// <param name="unitsToAdd">number of units to add</param>
        public void AddProducts(int unitsToAdd)
        {
            _numberOfUnits += unitsToAdd;
        }

        
        /// <summary>
        /// subtract products from the inventory
        /// </summary>
        /// <param name="unitsToSubtract">number of units to subtract</param>
        public void SubtractProducts(int unitsToSubtract)
        {
            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}

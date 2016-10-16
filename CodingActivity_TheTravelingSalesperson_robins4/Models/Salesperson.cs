using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson
{
    public class Salesperson
    {
        #region FIELDS
        //integers and strings to initiate within the console view
        private string _firstName;
        private string _lastName;
        private int _accountID;
        private string _productName;
        private int _productUnits;
        private int _age;
        private List<string> _locationsVisited;
        private int unitsAdded;
        private int unitsSubtracted;
        private int numberOfUnitsToSell;
        private int numberOfUnitsToAdd;
        

        #endregion

        #region PROPERTIES
        // properties used within the console view
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int ProductUnits
        {
            get { return _productUnits; }
            set { _productUnits = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public List<string> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public int UnitsAdded
        {
            get { return numberOfUnitsToAdd; }
           set { unitsAdded = numberOfUnitsToAdd; }
        }

        public int UnitsSubtracted
        {   
            get { return numberOfUnitsToSell; }
           set { unitsSubtracted = numberOfUnitsToSell; }
        }

        public int NumberOfUnitsToSell
        {
            get { return numberOfUnitsToSell; }
            set { numberOfUnitsToSell = value; }
        }

        public int NumberOfUnitsToAdd
        {
            get { return numberOfUnitsToAdd; }
            set { numberOfUnitsToAdd = value; }
        }


        #endregion


        #region CONSTRUCTORS
        //property constructors used within consoleview
        public Salesperson()
        {
            _locationsVisited = new List<string>();
        }

        public Salesperson(string firstName, string lastName, int accountId)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountID = accountId;
            _locationsVisited = new List<string>();

        }

        #endregion


        #region METHODS
    
        #endregion
    }
}

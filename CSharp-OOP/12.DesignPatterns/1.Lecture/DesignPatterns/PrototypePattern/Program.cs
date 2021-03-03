using System;

namespace PrototypePattern
{
    //With prototype pattern we clone objects
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country() {CountryName = "Austria"};
            City city = new City() { CityName = "Viena" }; ;

            Address address = new Address() 
            {
                Country = country, 
                City = city,
                Street = "VienShtrase 25"
            };

            //In the current program only the main clas address inherited the IClonable interface
            //This allowes to copy only the valute type properties and put refference to the reference data types (Properties created - Class)
            //In this case we can change only the value type properties, and if we change the reference type, the change will applay to the current object
            //and the objcet from which we copied the data - Shallow copy
            Address prototypeAddress = (Address)address.Clone();
            prototypeAddress.Street = "LampsumShtrase 31";
            prototypeAddress.City.CityName = "Sofia";

            Console.WriteLine(address);
            Console.WriteLine(prototypeAddress);

            //In the next case the logic is simillar but this time we will put IClonable to the reference type (Objects example - city, country)
            //and if we want to change the prop of their values the change will not apply to the object from which made the clone. - Deep Copy

            //Check for [Serializable] and Deep Clone method , binaryformatter
        }
    }
}

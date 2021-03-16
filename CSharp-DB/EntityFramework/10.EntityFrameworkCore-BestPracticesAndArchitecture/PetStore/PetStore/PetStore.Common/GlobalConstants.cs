namespace PetStore.Common
{
    public static class GlobalConstants
    {
        //Breed
        public const int BreedNameMinLength = 5;
        public const int BreedMaxLength = 30;

        //Client
        public const int UserNameMinLength = 6;
        public const int UserNameMaxLength = 30;
        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 15;
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 50;

        //Order
        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 30;
        public const int AddressNameMinLength = 5;
        public const int AddressNameMAxLength = 50;

        //ClientProduct
        public const int MinQuantity = 1;


        //Pet
        public const int PetNameMinLength = 3;
        public const int PetNameMaxLength = 30;
        public const int PetMinPrice = 1;
        public const int MinAgeRange = 0;
        public const int MaxAgeRange = 200;

        //Product
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 50;
        public const int ProductMinPrice = 0;
    }
}

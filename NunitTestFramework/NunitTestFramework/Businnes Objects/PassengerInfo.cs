using System;

namespace NunitTestFramework.Businnes_Objects
{
    /// <summary>
    /// Класс для хранения информации о пассажире. Заданы значения по умолчанию.
    /// </summary>
    public class PassengerInfo
    {
        public string Title { get; set; } = "Dr";
        public string Firstname { get; set; } = "James";
        public string Lastname { get; set; } = "Wilson";
        public DateTime DateOfBirth { get; set; } = new DateTime(DateTime.Now.Year - 25, 09, 29);
        public string Gender { get; set; } = "Male";
        public string Email { get; set; } = "JamesWilson@email.com";
        public string PhoneType { get; set; } = "Mobile";
        public string PhoneNumberLocal { get; set; } = "United States (1)";
        public string PhoneContactNumber { get; set; } = "2345678900";
        public string NumberCard { get; set; } = "5345123111123453";
        public string FirstnameCard { get; set; } = "James";
        public string LastnameCard { get; set; } = "Wilson";
        public DateTime ExpiryDateCard { get; set; } = new DateTime(DateTime.Now.Year + 3, 09, 29);
        public string SecurityCodeCard { get; set; } = "123";
        public string Country { get; set; } = "United States";
        public string HouseNameOrNumber { get; set; } = "11301";
        public string ZipCode { get; set; } = "90064";
        public string FullAdress { get; set; } = "#1901, 10390 Wilshire Blvd Apt 1, Los Angeles CA 90024-6400";

        public PassengerInfo() { }
        public PassengerInfo(string title, string firstname, string lastname, DateTime dateOfBirth, string gender,
            string email, string phoneType, string numberLocal, string contactNumber,
            string cardNumber, string firstnameCard, string lastnameCard, DateTime expiryDateCard, string securityCode,
            string country, string houseNameOrNumber, string zipCode, string fullAdress)
        {
            Title = title;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            PhoneType = phoneType;
            PhoneNumberLocal = numberLocal;
            PhoneContactNumber = contactNumber;
            NumberCard = cardNumber;
            FirstnameCard = firstnameCard;
            LastnameCard = lastnameCard;
            ExpiryDateCard = expiryDateCard;
            SecurityCodeCard = securityCode;
            Country = country;
            HouseNameOrNumber = houseNameOrNumber;
            ZipCode = zipCode;
            FullAdress = fullAdress;
        }
    }
}

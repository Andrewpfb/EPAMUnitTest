using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Класс страницы, где заполняется информация о пассажирах.
    /// </summary>
    public class PassengerInfoPages
    {
        #region Passenger Elements

        /// <summary>
        /// Элемент для выбора статуса (мистер, миссис, доктор и т.д.) пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "prefix0")]
        private IWebElement selectPassengerTitle;

        /// <summary>
        /// Элемент для ввода имени пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "firstName0")]
        private IWebElement passengerFirstName;

        /// <summary>
        /// Элемент для ввода фамилии пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "lastName0")]
        private IWebElement passengerLastName;

        /// <summary>
        /// Элемент для ввода дня рождения пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "day0")]
        private IWebElement selectPassengerDayOfBirth;

        /// <summary>
        /// Элемент для ввода месяца рождения пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "month0")]
        private IWebElement selectPassengerMonthOfBirth;

        /// <summary>
        /// Элемент для ввода года рождения пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "year0")]
        private IWebElement selectPassengerYearOfBirth;

        /// <summary>
        /// Элемент для выбора мужского пола.
        /// </summary>
        [FindsBy(How = How.Id, Using = "gender0")]
        private IWebElement passengerMaleGenderRadio;

        /// <summary>
        /// Элемент для выбора женского пола.
        /// </summary>
        [FindsBy(How = How.Id, Using = "gender10")]
        private IWebElement passengerFemaleGenderRadio;

        /// <summary>
        /// Элемент для ввода email-адреса.
        /// </summary>
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement passengerEmailAdress;

        /// <summary>
        /// Элемент для подтверждения email-адреса.
        /// </summary>
        [FindsBy(How = How.Id, Using = "reEmail")]
        private IWebElement confirmPassengerEmailAdress;

        /// <summary>
        /// Элемент для выбора типа телефона пассажира (мобильный ,рабочий и .т.д.). 
        /// </summary>
        [FindsBy(How = How.Id, Using = "deviceType")]
        private IWebElement selectPassengerPhoneType;

        /// <summary>
        /// Элемент для выбора кода страны для номера.
        /// </summary>
        [FindsBy(How = How.Id, Using = "countryCode0")]
        private IWebElement selectPassengerNumberLocal;

        /// <summary>
        /// Элемент для ввода контактного номера.
        /// </summary>
        [FindsBy(How = How.Id, Using = "telephoneNumber0")]
        private IWebElement passengerContactNumber;

        /// <summary>
        /// Элемент для ввода номера платежной карты пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "notLogInAccNumber")]
        private IWebElement passengerCardNumber;

        /// <summary>
        /// Элемент для ввода имени на платежной карте.
        /// </summary>
        [FindsBy(How = How.Id, Using = "notLogInFirstName")]
        private IWebElement passengerCardFirstname;

        /// <summary>
        /// Элемент для ввода фамилии на платежной карте.
        /// </summary>
        [FindsBy(How = How.Id, Using = "notLogInLastName")]
        private IWebElement passengerCardLastname;

        /// <summary>
        /// Элемент для выбора месяца конца срока действия платежной карты.
        /// </summary>
        [FindsBy(How = How.Id, Using = "notLogInExpMonth")]
        private IWebElement selectPassengerCardMonthExpire;

        /// <summary>
        /// Элемент для выбора года конца срока действия платежной карты.
        /// </summary>
        [FindsBy(How = How.Id, Using = "notLogInExpYear")]
        private IWebElement selectPassengerCardYearExpire;

        /// <summary>
        /// Элемент для ввода CVV/CVV2 платежной карты.
        /// </summary>
        [FindsBy(How = How.Id, Using = "cvv")]
        private IWebElement passengerCardSecurityNumber;

        /// <summary>
        /// Элемент для выбора страны проживания пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "countryCode")]
        private IWebElement selectPassengerCountry;

        /// <summary>
        /// Элемент для ввода номера или имени дома пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "houseNo")]
        private IWebElement passengerHouseNameOrNumber;

        /// <summary>
        /// Элемент для ввода почтового индекса пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "qasPostal")]
        private IWebElement passengerZipCode;

        /// <summary>
        /// Элемент для выбора адреса пассажира из списка найденных.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='addressList']/li/span[2]")]
        private IWebElement passengerFullAdress;

        #endregion

        #region Buttons

        /// <summary>
        /// Кнопка для подтверждения информации о пассажире
        /// </summary>
        [FindsBy(How = How.Id, Using = "pass_next")]
        private IWebElement buttonNextPass;

        /// <summary>
        /// Кнопка для подтверждения контактной информации о пассажире.
        /// </summary>
        [FindsBy(How = How.Id, Using = "paxReviewPurchaseBtn")]
        private IWebElement buttonNextContact;

        /// <summary>
        /// Кнопка для поиска адреса пассажира по указанным параметрам.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[. = 'Find address']")]
        private IWebElement buttonFindAdress;

        /// <summary>
        /// Кнопка для подтверждения оплаты заказа.
        /// </summary>
        [FindsBy(How = How.Id, Using = "continue_button")]
        private IWebElement buttonMakePayments;

        /// <summary>
        /// Элемент для соглашения с правилами перевозки.
        /// </summary>
        [FindsBy(How = How.Id, Using = "termsAndConditionCheck")]
        private IWebElement agreeTermsAndConditions;

        #endregion

        #region Errors

        /// <summary>
        /// Элемент, отображающий ошибку о нехватке информации о пассажире.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='pass_block']/div[1]/div/div[2]")]
        private IWebElement divErrorPassForm;

        /// <summary>
        /// Элемент, отображающий ошибку о некорректной дате рождения пассажира.
        /// </summary>
        [FindsBy(How = How.Id, Using = "errorContainerWrapper0")]
        private IWebElement divErrorInvalidYearOfBirthPassenger;

        /// <summary>
        /// Элемент, отображающий ошибку о некорректном номере платежной карты пассажира.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@id='paymentInfoErrorHolder']/div/p")]
        private IWebElement divErrorInvalidCardNumber;

        #endregion

        private IWebDriver driver;
        private SelectElement select;

        public PassengerInfoPages(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #region SetPassengerInfo

        #region Adult
        public void SetPassengerTitle(string title)
        {
            select = new SelectElement(selectPassengerTitle);
            select.SelectByText(title);
        }
        public void SetPassengerFirstname(string firstname)
        {
            passengerFirstName.SendKeys(firstname);
        }
        public void SetPassengerLastname(string lastname)
        {
            passengerLastName.SendKeys(lastname);
        }
        public void SetPassengerDayOfBirth(string dayOfBirth)
        {
            select = new SelectElement(selectPassengerDayOfBirth);
            select.SelectByText(dayOfBirth);
        }
        public void SetPassengerMonthOfBirth(string monthOfBirth)
        {
            select = new SelectElement(selectPassengerMonthOfBirth);
            select.SelectByText(monthOfBirth);
        }
        public void SetPassengerYearOfBirth(string year)
        {
            select = new SelectElement(selectPassengerYearOfBirth);
            select.SelectByText(year);
        }
        public void SetPassengerGenderMale()
        {
            passengerMaleGenderRadio.Click();
        }
        public void SetPassengerGenderFemale()
        {
            passengerFemaleGenderRadio.Click();
        }
        public void ConfirmPassInfo()
        {
            buttonNextPass.Click();
        }
        #endregion

        #region Contact Information
        public void SetPassengerEmail(string email)
        {
            Utils.WaitElements.WaitShowElement(By.Id("email"), driver);
            passengerEmailAdress.SendKeys(email);
        }
        public void ConfirmPassengerEmail(string email)
        {
            confirmPassengerEmailAdress.SendKeys(email);
        }
        public void SetPassengerPhoneType(string type)
        {
            select = new SelectElement(selectPassengerPhoneType);
            select.SelectByText(type);
        }
        public void SetPassengerPhoneLocale(string locale)
        {
            select = new SelectElement(selectPassengerNumberLocal);
            select.SelectByText(locale);
        }
        public void SetPassengerPhoneNumber(string number)
        {
            passengerContactNumber.SendKeys(number);
        }
        public void ConfirmContactInfo()
        {
            buttonNextContact.Click();
        }
        #endregion

        #region Payment
        public void SetPassengerCardNumber(string cardNumber)
        {
            passengerCardNumber.SendKeys(cardNumber);
        }
        public void SetPassengerCardFirstname(string firstname)
        {
            passengerCardFirstname.SendKeys(firstname);
        }
        public void SetPassengerCardLastname(string lastname)
        {
            passengerCardLastname.SendKeys(lastname);
        }
        public void SetPassengerCardMonthExpire(string month)
        {
            select = new SelectElement(selectPassengerCardMonthExpire);
            select.SelectByText(month);
        }
        public void SetPassengerCardYearExpire(string year)
        {
            select = new SelectElement(selectPassengerCardYearExpire);
            select.SelectByText(year);
        }
        public void SetPassengerCardSecurityNumber(string securityNumber)
        {
            passengerCardSecurityNumber.SendKeys(securityNumber);
        }
        #endregion

        #region Billing adress
        public void SetPassengerCountry(string country)
        {
            select = new SelectElement(selectPassengerCountry);
            select.SelectByText(country);
        }
        public void SetPassengerHouseNameOrNumber(string houseNameOrNumber)
        {
            passengerHouseNameOrNumber.SendKeys(houseNameOrNumber);
        }
        public void SetPassengerZipCode(string zipCode)
        {
            passengerZipCode.SendKeys(zipCode);
        }
        public void FindAdress()
        {
            buttonFindAdress.Click();
        }
        public bool GetAdress(string fullAdress)
        {
            return passengerFullAdress.Text == fullAdress;
        }
        public void ConfirmAdress()
        {
            passengerFullAdress.Click();
        }
        #endregion

        #endregion

        public void AgreeTermsAndCondition()
        {
            agreeTermsAndConditions.Click();
        }
        public void ConfirmPayments()
        {
            buttonMakePayments.Click();
        }

        public bool GetErrorEmptyPassInfo(string[] message)
        {
            //В окне ошибки содержится список неверных данных. Метод проверяет список на соответствие заранее
            //заданному массиву ошибок.
            bool result = false;
            int index = 2;
            IWebElement tmp = driver.FindElement(By.XPath("//*[@id='pass_block']/div[1]/div/div[2]/div"));
            result = divErrorPassForm.FindElement(By.TagName("p")).Text == message[0];
            result = tmp.FindElement(By.TagName("h4")).Text == message[1];
            tmp = driver.FindElement(By.XPath("//*[@id='pass_block']/div[1]/div/div[2]/div/ul"));
            if (result == false)
            {
                return result;
            }
            foreach (var li in tmp.FindElements(By.TagName("li")))
            {
                result = li.Text == message[index];
                index++;
                if (result == false)
                {
                    return result;
                }
            }
            return result;
        }
        public bool GetErrorInvalidYearOfBirth(string message)
        {
            return divErrorInvalidYearOfBirthPassenger.Text == message;
        }
        public bool GetErrorInvalidCardNumber(string message)
        {
            return divErrorInvalidCardNumber.Text == message;
        }
    }
}

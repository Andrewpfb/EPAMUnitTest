using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NunitTestFramework.Utils
{
    /// <summary>
    /// Класс для ожидания элементов.
    /// Содержит методы ожидания появления и скрытия элементов.
    /// </summary>
    public class WaitElements
    {
        /// <summary>
        /// Метод ожидает появление элемента на странице.
        /// </summary>
        /// <param name="iClassName">Локатор для поиска элемента.</param>
        /// <param name="webDriver">Объект WebDriver.</param>
        public static void WaitShowElement(By iClassName, IWebDriver webDriver)
        {
            WebDriverWait iWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            iWait.Until(ExpectedConditions.ElementIsVisible(iClassName));
        }
        /// <summary>
        /// Метод ожидает исчезновение элемента со страницы.
        /// </summary>
        /// <param name="iClassName">Локатор для поиска элемента</param>
        /// <param name="webDriver">Объект WebDriver</param>
        public static void WaitHideElement(By iClassName, IWebDriver webDriver)
        {
            WebDriverWait iWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            iWait.Until(ExpectedConditions.InvisibilityOfElementLocated(iClassName));
        }
    }
}

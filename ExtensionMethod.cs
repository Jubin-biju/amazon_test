using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTakeExtenasion
{
    public static class ExtensionMethods
    {
        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }
    }
}

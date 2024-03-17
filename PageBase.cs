using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTake
{
    public class PageBase
    {
        public BaseDriver first;

        public IWebDriver driver => first.driver;
        public PageBase(BaseDriver Driver) 
        { 
            first = Driver;
        }
    }
}

package com.ministryoftesting.tests;

import com.ministryoftesting.driverfactory.DriverFactory;
import com.ministryoftesting.pageobjects.HomePage;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import static org.junit.Assert.assertEquals;

//    Welcome to UI Automation Challenge 5
//
//    For this challenge we're thinking about how we create the
//    necessary code to run our test across different browsers
//    easily and with minimal manual intervention. Update the
//    browser factory so that it can support the running of the
//    test across multiple browsers

public class Challenge5Tests {

    WebDriver driver;

    @Before
    public void buildDriver(){
        DriverFactory driverFactory = new DriverFactory();
        driver = driverFactory.create();
    }

    @Test
    public void checkTheHomePageData(){
        driver.navigate().to("https://automationintesting.online/");

        HomePage homePage = new HomePage(driver);

        String imgUrl = homePage.getHotelLogo().getAttribute("src");
        assertEquals("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);
    }

}

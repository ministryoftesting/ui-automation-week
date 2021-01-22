package com.ministryoftesting.tests;

import com.ministryoftesting.pageobjects.HomePage;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import static org.junit.Assert.assertEquals;

//    Welcome to UI Automation Challenge 3
//
//    For this challenge the focus is improving the assertion for an existing
//    UI automation test. Rather than asserting on the DOM's state, update the
//    the test below to do a visual check of the page. Once you've completed
//    the sample check. Create your own example check.

public class Challenge3Tests {

    WebDriver driver;

    @Before
    public void buildDriver(){
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
    }

    @Test
    public void checkTheHomePageData(){
        driver.navigate().to("https://automationintesting.online/");

        HomePage homePage = new HomePage(driver);

        String imgUrl = homePage.getHotelLogo().getAttribute("src");
        assertEquals("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);

        int roomImageCount = homePage.getRoomImageCount();
        assertEquals(1, roomImageCount);

        int mapCounts = homePage.getMapImageCount();
        assertEquals(16, mapCounts);
    }

//    @Test
//    public void yourTurn(){
//        Create your own demonstration of a visual check
//    }

}

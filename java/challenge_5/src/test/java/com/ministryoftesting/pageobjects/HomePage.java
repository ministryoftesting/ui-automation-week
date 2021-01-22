package com.ministryoftesting.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.List;

public class HomePage extends BasePage {

    @FindBy(how = How.CSS, using = ".hotel-logoUrl")
    private WebElement imgHotelLogo;

    public HomePage(WebDriver driver) {
        super(driver);

        WebDriverWait wait = new WebDriverWait(driver, 10);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector(".openBooking")));
    }

    public WebElement getHotelLogo(){
        return imgHotelLogo;
    }

}

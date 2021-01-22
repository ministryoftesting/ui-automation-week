package com.ministryoftesting;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import java.util.List;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.CoreMatchers.not;
import static org.junit.Assert.assertThat;

public class Challenge2Tests {

//    Welcome to UI Automation Challenge 2
//
//    For this challenge it's all about creating clean, readable and maintainable code. Below
//    are five tests that work (just about) but require cleaning up. Update this class so that
//    code base so that it's easier to maintain, more readable and has sensible ways of asserting
//    data. You might want to research different approaches to improving UI automation such as
//    Page Object Models and implicit vs. explicit waits

//  Test one: Check to see if you can log in with valid credentials
    @Test
    public void loginTest() throws InterruptedException {
        WebDriverManager.chromedriver().setup();
        WebDriver driver = new ChromeDriver();

        driver.navigate().to("https://automationintesting.online/#/");
        driver.findElement(By.cssSelector("footer p a:nth-child(5)")).click();
    Thread.sleep(1000);
        driver.findElement(By.xpath("//div[@class=\"form-group\"][1]/input")).sendKeys("admin");
        Thread.sleep(1000);
        driver.findElement(By.xpath("//div[@class=\"form-group\"][2]/input")).sendKeys("password");
        Thread.sleep(1000);
        driver.findElement(By.className("float-right")).click();


        Thread.sleep(5000);

    WebElement webElement = driver.findElement(By.className("navbar-collapse"));
    System.out.println(webElement.getText());
    Boolean title = webElement.getText().contains("Rooms");

        assertThat(true, is(title));
    }

//  Test two: Check to see if rooms are saved and displayed in the UI
    @Test
    public void room() throws InterruptedException {
        WebDriverManager.chromedriver().setup();
        WebDriver driver = new ChromeDriver();

        driver.navigate().to("https://automationintesting.online/#/");
        driver.findElement(By.xpath("//a[@href=\"/#/admin\"]")).click();

        Thread.sleep(3600);

        driver.findElement(By.xpath("//div[@class=\"form-group\"][1]/input")).sendKeys("admin");
        Thread.sleep(1000);
        driver.findElement(By.xpath("//div[@class=\"form-group\"][2]/input")).sendKeys("password");
        Thread.sleep(1000);
        driver.findElement(By.className("float-right")).click();

        Thread.sleep(2000);

        driver.findElement(By.cssSelector(".room-form > div:nth-child(1) input")).sendKeys("101");
        driver.findElement(By.cssSelector(".room-form > div:nth-child(4) input")).sendKeys("101");
        Thread.sleep(1000);
        driver.findElement(By.className("btn-outline-primary")).click();

        Thread.sleep(5000);

        assertThat(driver.findElements(By.className(".detail")).size(), not(1));
    }

//  Test three: Check to see the confirm message appears when branding is updated
    @Test
    public void updateBrandin() throws InterruptedException {
        WebDriverManager.chromedriver().setup();
        WebDriver driver = new ChromeDriver();

        driver.get("https://automationintesting.online/#/admin");

        driver.findElement(By.xpath("//div[@class=\"form-group\"][1]/input")).sendKeys("admin");
        Thread.sleep(1000);
        driver.findElement(By.xpath("//div[@class=\"form-group\"][2]/input")).sendKeys("password");
        Thread.sleep(1000);
        driver.findElement(By.className("float-right")).click();

        driver.get("https://automationintesting.online/#/admin/branding");

        Thread.sleep(5000);

        driver.findElement(By.className("form-control")).sendKeys("Test");
        driver.findElement(By.className("btn-outline-primary")).click();

        Thread.sleep(1001);

        int count = driver.findElements(By.xpath("//button[text()=\"Close\"]")).size();

        if(count == 1){
            assertThat(true, is(true));
        } else {
            assertThat(true, is(Boolean.FALSE));
        }
    }

    WebDriver driver;

//  Test four: Check to see if the contact form shows a success message
    @Test
    public void ContectCheck() throws InterruptedException {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();

        driver.navigate().to("https://automationintesting.online");

        driver.findElement(By.cssSelector("input[placeholder=\"Name\"]")).sendKeys("TEST123");
        driver.findElement(By.cssSelector("input[placeholder=\"Email\"]")).sendKeys("TEST123@TEST.COM");
        driver.findElement(By.cssSelector("input[placeholder=\"Phone\"]")).sendKeys("01212121311");
        driver.findElement(By.cssSelector("input[placeholder=\"Subject\"]")).sendKeys("TEsTEST");
        driver.findElement(By.cssSelector("textarea")).sendKeys("TEsTESTTEsTESTTEsTEST");
        Thread.sleep(2000);
        driver.findElement(By.xpath("//button[text()=\"Submit\"]")).click();


        Thread.sleep(4000);
        assertThat(driver.findElement(By.cssSelector(".contact")).getText().contains("Thanks for getting in touch"), is(true));
}

//  Test five: Check to see if unread messages are bolded
    @Test
    public void isTheMessageBoldWhenUnreadInTheMEssageViwe() throws InterruptedException {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();

        driver.navigate().to("https://automationintesting.online/#/admin/messages");

        driver.findElement(By.xpath("//div[@class=\"form-group\"][1]/input")).sendKeys("admin");
        Thread.sleep(1000);
        driver.findElement(By.xpath("//div[@class=\"form-group\"][2]/input")).sendKeys("password");
        Thread.sleep(1000);
        driver.findElement(By.className("float-right")).click();

        Thread.sleep(3000);





        assertThat(checkCount(driver.findElements(By.cssSelector(".read-false"))), is(true));
    }

    private Boolean checkCount(List<WebElement> elements) {
        if(elements.size() >= 1){
            return true;
        }

        return false;
    }
}

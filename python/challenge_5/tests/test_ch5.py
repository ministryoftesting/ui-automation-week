""" Welcome to UI Automation Challenge 5

For this challenge we're thinking about how we create the
necessary code to run our test across different browsers
easily and with minimal manual intervention. Update the
browser factory so that it can support the running of the
test across multiple browsers.

> Pylenium has a DriverFactory built-in,
  so try using just Selenium for this challenge to create your own.
"""
import pytest
from selenium.webdriver.remote.webdriver import WebDriver
from python.challenge_5.driver import factory
from python.challenge_5.pages.home_page import HomePage


@pytest.fixture
def driver():
    return factory.create()


@pytest.fixture
def home(driver):
    return HomePage(driver)


def test_the_home_page_data(driver: WebDriver, home: HomePage):
    driver.get('https://automationintesting.online/')
    img_url = home.get_hotel_logo().get_attribute('src')
    assert 'https://www.mwtestconsultancy.co.uk/img/rbp-logo.png' == img_url

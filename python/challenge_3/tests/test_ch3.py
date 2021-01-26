""" Welcome to UI Automation Challenge 3

For this challenge the focus is improving the assertion for an existing
UI automation test. Rather than asserting on the DOM's state, update the
the test below to do a visual check of the page. Once you've completed
the sample check. Create your own example check.

> Remember, Pylenium is just a wrapper of Selenium, so you already have access to Selenium!
"""
import pytest
from pylenium.driver import Pylenium
from python.challenge_3.pages.home_page import HomePage


@pytest.fixture
def home(py):
    py.visit("https://automationintesting.online/");
    return HomePage(py)


def test_check_the_home_page_data(home: HomePage):
    img_url = home.get_hotel_logo().get_attribute('src')
    assert "https://www.mwtestconsultancy.co.uk/img/rbp-logo.png" == img_url
    assert home.get_room_images().should().have_length(1)
    assert home.get_map_image_count().should().have_length(28)


def test_your_turn(py: Pylenium, home: HomePage):
    """ Create your own demonstration of a visual check """
    pass

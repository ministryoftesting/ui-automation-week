""" Welcome to UI Automation Challenge 5

For this challenge we're thinking about how we create the
necessary code to run our test across different browsers
easily and with minimal manual intervention. Update the
browser factory so that it can support the running of the
test across multiple browsers.

> Pylenium has a DriverFactory built-in,
  so you can do this via the CLI or with the pylenium.json

## BONUS
Try to Dockerize/Containerize your tests and run them in parallel!

Helpful links:
* https://elsnoman.gitbook.io/pylenium/testing/run-tests-in-containers
* https://elsnoman.gitbook.io/pylenium/testing/run-tests-in-parallel
"""
import pytest
from pylenium.driver import Pylenium
from python.challenge_5.pages.home_page import HomePage


@pytest.fixture
def home(py):
    return HomePage(py)


def test_the_home_page_data(py: Pylenium, home: HomePage):
    py.visit('https://automationintesting.online/')
    assert home.get_hotel_logo().should().have_attr('src', 'https://www.mwtestconsultancy.co.uk/img/rbp-logo.png')

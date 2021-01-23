"""
Welcome to UI Automation Challenge 2

For this challenge it's all about creating clean, readable and maintainable code. Below
are five tests that work (just about) but require cleaning up. Update this
code base so that it's easier to maintain, more readable and has sensible ways of asserting
data. You might want to research different approaches to improving UI automation such as
Page Object Models.
"""
import time
from pylenium.driver import Pylenium


def test_login(py: Pylenium):
    """ Test 1: Check to see if you can log in with valid credentials """
    py.visit('https://automationintesting.online/#/')
    py.get('footer p a:nth-child(5)').click()
    py.getx('//div[@class=\'form-group\'][1]/input').type('admin')
    py.getx("//div[@class=\"form-group\"][2]/input").type('password')
    py.get(".float-right").click()

    time.sleep(3)
    element = py.get('.navbar-collapse')
    print(element.text())
    title = 'Rooms' in element.text()
    assert True is title


def test_room(py: Pylenium):
    """ Test 2: Check to see if rooms are saved and displayed in the UI """
    py.visit("https://automationintesting.online/#/")
    py.getx("//a[@href=\"/#/admin\"]").click()
    py.getx("//div[@class=\"form-group\"][1]/input").type('admin')
    py.getx("//div[@class=\"form-group\"][2]/input").type('password')
    py.get('.float-right').click()

    py.get(".room-form > div:nth-child(1) input").type('101')
    py.get(".room-form > div:nth-child(4) input").type('101')
    time.sleep(3)
    py.get(".btn-outline-primary").click()
    assert py.find('.detail').length() != 1


def test_update_branding(py: Pylenium):
    """ Test 3: Check to see the confirm message appears when branding is updated """
    py.visit("https://automationintesting.online/#/admin")
    py.getx("//a[@href=\"/#/admin\"]").click()
    py.getx("//div[@class=\"form-group\"][1]/input").type('admin')
    py.getx("//div[@class=\"form-group\"][2]/input").type('password')
    py.get('.float-right').click()

    py.visit("https://automationintesting.online/#/admin/branding")
    py.get('.form-control').type('Test')
    py.get('.btn-outline-primary').click()

    count = py.findx("//button[text()=\"Close\"]").length()

    if count == 1:
        assert True is (True)
    else:
        assert True is False


def test_contact_check(py: Pylenium):
    """ Test 4: Check to see if the contact form shows a success message """
    py.visit("https://automationintesting.online")

    py.get("input[placeholder=\"Name\"]").type('TEST123')
    py.get("input[placeholder=\"Email\"]").type('TEST123@TEST.COM')
    py.get("input[placeholder=\"Phone\"]").type('01212121311')
    py.get("input[placeholder=\"Subject\"]").type('TesTEST')
    py.get('textarea').type('TEsTESTTEsTESTTEsTEST')
    py.getx("//button[text()=\"Submit\"]").click()

    time.sleep(4)
    assert ('Thanks for getting in touch' in py.get('.contact').text()) is True


def test_is_the_message_bold_when_unread_in_the_message_view(py: Pylenium):
    """ Test 5: Check to see if unread messages are bolded """
    py.visit("https://automationintesting.online/#/admin/messages");
    py.getx("//div[@class=\"form-group\"][1]/input").type('admin')
    py.getx("//div[@class=\"form-group\"][2]/input").type('password')
    py.get('.float-right').click()
    assert check_count(py.find('.read-false')) is True

def check_count(elements):
    if elements.length() >= 1:
        return True
    return False

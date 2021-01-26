from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC


class HomePage:
    def __init__(self, driver: WebDriver):
        self.driver = driver
        self.wait = WebDriverWait(driver, timeout=10)
        self.wait.until(EC.visibility_of_element_located(locator=(By.CSS_SELECTOR, '.openBooking')))

    _IMG_HOTEL_LOGO = By.CSS_SELECTOR, '.hotel-logoUrl'

    def get_hotel_logo(self) -> WebElement:
        return self.driver.find_element(self._IMG_HOTEL_LOGO)

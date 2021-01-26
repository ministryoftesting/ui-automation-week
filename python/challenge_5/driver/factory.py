from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager

def create():
    return webdriver.Chrome(ChromeDriverManager().install())

from pylenium.driver import Pylenium
from pylenium.element import Element


class HomePage:
    def __init__(self, py: Pylenium):
        self.py = py

    _IMG_HOTEL_LOGO = '.hotel-logoUrl'

    def get_hotel_logo(self) -> Element:
        return self.py.get(self._IMG_HOTEL_LOGO)

from pylenium.driver import Pylenium
from pylenium.element import Element, Elements


class HomePage:
    def __init__(self, py: Pylenium):
        self.py = py

    _IMG_HOTEL_LOGO = '.hotel-logoUrl'
    _IMG_ROOMS = '.hotel-img'
    _IMG_MAPS = '.map img'

    def get_hotel_logo(self) -> Element:
        return self.py.get(self._IMG_HOTEL_LOGO)

    def get_room_images(self) -> Elements:
        return self.py.find(self._IMG_ROOMS)

    def get_map_image_count(self) -> Elements:
        return self.py.find(self._IMG_MAPS)

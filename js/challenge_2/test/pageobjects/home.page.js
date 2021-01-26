
class HomePage {
    /**
     * define selectors using getter methods
     */
    get imgHotelLogo () { return $('.hotel-logoUrl') }
    get imgRooms () { return $('.hotel-img') }
    get imgMaps () { return $('.map img') }

}

module.exports = new HomePage();

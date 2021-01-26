const HomePage = require('../pageobjects/home.page');

describe('image check', () => {
    it('should check the home page images', () => {

        browser.url('https://automationintesting.online/');

        expect(HomePage.imgRooms).toHaveLength(1);
        expect(HomePage.imgMaps).toHaveLength(16);

        expect(HomePage.imgHotelLogo).toHaveAttr('src', 'https://www.mwtestconsultancy.co.uk/img/rbp-logo.png')
    });

    // it('your turn', () => {
    //     Create your own demonstration of a visual check
    // });

});


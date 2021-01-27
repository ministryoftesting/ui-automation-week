const HomePage = require('../pageobjects/home.page');

//    Welcome to UI Automation Challenge 3
//
//    For this challenge the focus is improving the assertion for an existing
//    UI automation test. Rather than asserting on the DOM's state, update the
//    the test below to do a visual check of the page. Once you've completed
//    the sample test, create your own example test.


describe('Challenge 3 Tests', () => {
    it('should check the home page images', () => {

        browser.url('https://automationintesting.online/');

        expect(HomePage.imgRooms.length).toEqual(1);
        expect(HomePage.imgMaps.length).toEqual(16);

        const src = HomePage.imgHotelLogo.getAttribute('src');
        expect(src).toEqual('https://www.mwtestconsultancy.co.uk/img/rbp-logo.png')
    });

    // it('your turn', () => {
    //     Create your own demonstration of a visual check
    // });

});


const HomePage = require('../pageobjects/home.page');

//    Welcome to UI Automation Challenge 5
//
//    For this challenge we're thinking about how we create the
//    necessary code to run our test across different browsers
//    easily and with minimal manual intervention.


describe('My Login application', () => {
    it('Check home page logo', () => {
        browser.url('https://automationintesting.online/')

        expect(HomePage.imgHotelLogo).toHaveAttr('src', 'https://www.mwtestconsultancy.co.uk/img/rbp-logo.png')
    });
});

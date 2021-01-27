const HomePage = require('../pageobjects/home.page');

//    Welcome to UI Automation Challenge 5
//
//    For this challenge we're thinking about how we create the
//    necessary code to run our test across different browsers
//    easily and with minimal manual intervention. 
//    Update the wdio.conf.js so that it can support the running of the
//    test across multiple browsers


describe('Challenge 5 Tests', () => {
    it('Check home page logo', () => {
        browser.url('https://automationintesting.online/')

        const src = HomePage.imgHotelLogo.getAttribute('src');

        expect(src).toEqual('https://www.mwtestconsultancy.co.uk/img/rbp-logo.png')
    });
});

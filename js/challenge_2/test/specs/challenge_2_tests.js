
// Test one: Check to see if you can log in with valid credentials
// For this challenge it's all about creating clean, readable and maintainable code. Below
// are five tests that work (just about) but require cleaning up. Update this
// code base so that it's easier to maintain, more readable and has sensible ways of asserting
// data. You might want to research different approaches to improving UI automation such as
// Page Object Models.

describe('Challenge 2 tests', () => {
    beforeEach(() => {
        browser.reloadSession();
    })

    // Test one: Check to see if you can log in with valid credentials
    it('should be able to login', () => {
        browser.url('https://automationintesting.online/#/')
        $('footer p a:nth-child(5)').click();
        $('//div[@class=\"form-group\"][1]/input').click();
        $('//div[@class=\"form-group\"][1]/input').setValue('admin');
        $('//div[@class=\"form-group\"][2]/input').setValue('password');

        $('button.float-right').click();

        browser.pause(3000);
        const element = $('div.navbar-collapse');
        const title = element.getText();

        expect(title).toContain('Rooms');
    })

    //Test two: Check to see if rooms are saved and displayed in the UI
    it('should be able to save rooms', () => {
        browser.url('https://automationintesting.online/#/')
        $('//a[@href=\"/#/admin\"]').click();
        $('//div[@class=\"form-group\"][1]/input').setValue('admin');
        $('//div[@class=\"form-group\"][2]/input').setValue('password');

        $('button.float-right').click();

        $('.room-form > div:nth-child(1) input').setValue('101');
        $('.room-form > div:nth-child(4) input').setValue('101');

        browser.pause(2000);
        $('button.btn-outline-primary').click();

        // browser.debug();

        // assertThat(driver.findElements(By.className(".detail")).size(), not(1));
    })


    // Test three: Check to see the confirm message appears when branding is updated
    it('should be able to update branding', () => {
        browser.url('https://automationintesting.online/#/admin')
        $('//div[@class=\"form-group\"][1]/input').setValue('admin');
        $('//div[@class=\"form-group\"][2]/input').setValue('password');

        $('button.float-right').click();

        browser.url('https://automationintesting.online/#/admin/branding');

    
        $('input.form-control').setValue("Test");
        $('button.btn-outline-primary').click();

        browser.pause(1000);
        const elementCount = $$('//button[text()="Close"]').length;

        if (elementCount === 1) { 
            expect(true).toBe(true)
        } else {
            expect(true).toBe(false)
        }
    })

    // Test four: Check to see if the contact form shows a success message
     it('should see success message', () => {
        browser.url('https://automationintesting.online')

        $('input[placeholder=\"Name\"]').setValue('TEST123');
        $('input[placeholder=\"Email\"]').setValue('TEST123@TEST.COM');
        $('input[placeholder=\"Phone\"]').setValue('01212121311');
        $('input[placeholder=\"Subject\"]').setValue('TEsTEST');
        $('textarea').setValue('TEsTESTTEsTESTTEsTEST');

        $("//button[text()=\"Submit\"]").click();

        browser.pause(3000);
        expect($("div.contact").getText()).toContain('Thanks for getting in touch')
    })

    // Test five: Check to see if unread messages are bolded
    it('should see unread messages are bolded', () => {
        browser.url('https://automationintesting.online/#/admin/messages')

        $('//div[@class=\"form-group\"][1]/input').setValue('admin');
        $('//div[@class=\"form-group\"][2]/input').setValue('password');

        $('button.float-right').click();

        browser.pause(2000);

        expect($$('div.read-false').length).toBeGreaterThanOrEqual(1);
    })


})

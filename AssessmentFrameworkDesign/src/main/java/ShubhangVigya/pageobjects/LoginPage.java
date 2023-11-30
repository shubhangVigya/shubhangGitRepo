package ShubhangVigya.pageobjects;

import org.openqa.selenium.WebDriver;

public class LoginPage extends BasePage{
	
	WebDriver driver;
	
	
	
	
	public LoginPage(WebDriver driver)
	{
		//initialization of driver
		super(driver); // Gives life to driver in parent class
		this.driver = driver;		
		
	}

		
	public BookingPage loginApplication(String userName, String password)
	{
		userEmail.sendKeys(userName); // Enters user Credentials
		passwordEle.sendKeys(password);
		login.click();
		BookingPage bookingPage = new BookingPage(driver); // Create object for next expected page
		return bookingPage;
	}
}

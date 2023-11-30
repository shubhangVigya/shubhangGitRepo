package ShubhangVigya.pageobjects;

import org.openqa.selenium.WebDriver;

public class LandingPage extends BasePage{
	
	WebDriver driver;
	
	public LandingPage(WebDriver driver)
	{
		//initialization
		super(driver); // Gives life to driver in parent class
		this.driver = driver;
		
	}

	public void goTo()
	{
		driver.get("https://katalon-demo-cura.herokuapp.com/");
	}
	public LoginPage landingApplication()
	{
		appointment.click(); // user enters to login screen
		LoginPage loginPage = new LoginPage(driver); // Create object for next expected page
		return loginPage;
	}
}

package daft.TestComponent;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterMethod;

import daft.pageobjects.LandingPage;

public class BaseTest {

	public WebDriver driver;

	// Initialize Chrome driver and create object for next page/landing page class
	public LandingPage initializeDriver() {
		driver = new ChromeDriver(); 

		driver.manage().window().maximize(); // Maximize window screen
		LandingPage landingPage = new LandingPage(driver); 
		landingPage.goTo();
		landingPage.acceptPrivacy();
		return landingPage;
	}

	// Close the current window of our test case
	@AfterMethod(alwaysRun = true)
	public void TearDown() {
		driver.quit();
	}
}

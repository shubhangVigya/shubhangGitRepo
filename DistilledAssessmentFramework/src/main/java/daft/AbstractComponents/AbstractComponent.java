package daft.AbstractComponents;

import java.time.Duration;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class AbstractComponent {

	
	//WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(5));
			//wait.until(ExpectedConditions.invisibilityOfElementLocated(By.))
	WebDriver driver;
	public AbstractComponent(WebDriver driver)
	{
		this.driver = driver;
		//PageFactory.initElements(driver, this); //gives life to driver in Locators following page factory pattern
		
	}
	

	public void waitForElementToAppear(By Locator)
	{
		WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(5));
		wait.until(ExpectedConditions.visibilityOfElementLocated(Locator));
	}
}

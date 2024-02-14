package daft.AbstractComponents;

import java.time.Duration;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class AbstractComponent {


	WebDriver driver; 
	public AbstractComponent(WebDriver driver)
	{
		this.driver = driver; //Initialize driver from child class
		
		
	}
	
    // Reusable Method for Explicit wait
	public void waitForElementToAppear(By Locator)
	{
		WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(5));
		wait.until(ExpectedConditions.visibilityOfElementLocated(Locator));
	}
}
